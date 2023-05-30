using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace FIXAnalyzer
{
    public partial class Form1:Form
    {
        Dictionary<char, string> OrdStatusToStr = new Dictionary<char, string>();
        Dictionary<char, string> OrdTypeToStr = new Dictionary<char, string>();

        Dictionary<string, Account> Accounts = new Dictionary<string, Account>();
        private Button btn_history;
        public Form1()
        {
            OrdStatusToStr = new Dictionary<char, string>
            {
                { '0', "New" },
                { '1', "Partially filled" },
                { '2', "Filled" },
                { '3', "Done for day" },
                { '4', "Canceled" },
                { '5', "Replaced" },
                { '6', "Pending Cancel" },
                { '7', "Stopped" },
                { '8', "Rejected" },
                { '9', "Suspended" },
                { 'A', "Pending New" },
                { 'B', "Calculated" },
                { 'C', "Expired" }
            };

            OrdTypeToStr = new Dictionary<char, string>()
            {
                { '1',"Market"},
                { '2',"Limit"},
                {'3',"Stop / Stop Loss"},
                {'4',"Stop Limit"},
                {'5',"Market On Close"},
                {'K',"Market With Left"},
            };

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = false;
            file.InitialDirectory = @"C:\";
            if( file.ShowDialog() != DialogResult.OK )
            {
                return;
            }

            txt_fixPath.Text = file.FileName;


            var lines = File.ReadAllLines(txt_fixPath.Text);
            Parse(lines);
            foreach( var account in Accounts.Values )
            {
                foreach( var order in account.Orders.Values )
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(grid, order.OrderId, account.AccountID, $"{OrdTypeToStr[order.OrdType]}({order.OrdType})", $"{OrdStatusToStr[order.OrdStatus]}({order.OrdStatus})", order.TrdMatchID, order.Side, order.Qty, order.Price, order.Symbol, order.TimeInForce, order.LeavesQty, btn_history);
                    grid.Rows.Add(row);
                }
            }
            FillControls(Accounts);
        }

        void FillControls(Dictionary<string, Account> Accounts)
        {
            foreach( var account in Accounts )
            {
                if( combo_acc.Items.Contains(account.Key) )
                    continue;

                combo_acc.Items.Add(account.Key);

                foreach( var order in account.Value.Orders )
                {
                    if( combo_ordID.Items.Contains(order.Value.OrderId) )
                        continue;

                    combo_ordID.Items.Add(order.Value.OrderId);
                }
            }
        }

        private void Parse(string[] lines)
        {
            int lineCount = 1;
            foreach( var line in lines )
            {

                var parts = line.Split('\x01');
                Dictionary<string, string> kv = new Dictionary<string, string>();
                foreach( var part in parts )
                {
                    var field = part.Split('=');
                    if( field.Length == 2 )
                        kv[field[0]] = field[1];
                }

                if( !kv.ContainsKey("35") )
                    throw new Exception($"tag 35 not found!, line: {lineCount}");

                var msgType = kv["35"];
                if( msgType == "8" ) //Execution Report
                {
                    var accountID = kv["1"];
                    if( !Accounts.ContainsKey(accountID) )
                    {
                        Accounts.Add(accountID, new Account() { AccountID = accountID, Orders = new Dictionary<string, Order>() });
                    }

                    AddOrUpdateOrder(Accounts[accountID], kv);
                }

                lineCount++;
            }

        }

        private void AddOrUpdateOrder(Account account, Dictionary<string, string> kv)
        {

            var orderID = kv["37"];

            if( !account.Orders.ContainsKey(orderID) )
            {
                account.Orders.Add(orderID, new Order()
                {
                    OrderId = orderID,
                    History = new List<Dictionary<string, Order>>()
                });

            }

            var order = account.Orders[orderID];

            var ordStatus = kv["39"][0];
            //0:new
            //1:partially filled
            //2:filled
            //4:canceled
            //5:replaced

            var orderCopy = new Dictionary<string, Order>();


            if( ordStatus == '0' || ordStatus == '1' || ordStatus == '2' || ordStatus == '5' )
            {
                order.OrdType = kv["40"][0];

                string timeInForce = kv["59"].ToString();
                switch( timeInForce )
                {
                    case "0":
                        order.TimeInForce = "Day";
                        break;
                    case "1":
                        order.TimeInForce = "Good Till Cancel";
                        break;
                    case "2":
                        order.TimeInForce = "At The Opening";
                        break;
                    case "3":
                        order.TimeInForce = "Immediate or Cancel";
                        break;
                    case "4":
                        order.TimeInForce = "Fill or Kill";
                        break;
                    case "5":
                        order.TimeInForce = "Good Till Crossing";
                        break;
                    case "6":
                        order.TimeInForce = "Good Till Date";
                        break;
                    default:
                        break;
                }
            }

            order.Side = kv["54"][0];
            order.Symbol = kv["55"].ToString();
            if( !kv.ContainsKey("41") && (ordStatus== '1' || ordStatus == '2') )
            {
                order.TrdMatchID = kv["880"].ToString();
            }
                

            if( kv.ContainsKey("44") )
            {
                order.Price = kv["44"].ToDecimal();
            }

            order.Qty = kv["38"].Split('.')[0].ToInt32();
            order.LeavesQty = kv["151"].Split('.')[0].ToInt32();
            if( kv.ContainsKey("14") )
            {
                var deb = kv["14"].Split('.')[0].ToInt32();
                if( deb > 0 )
                    order.FillQty = kv["14"].Split('.')[0].ToInt32();
            }
            order.OrdStatus = kv["39"][0];

            foreach( var entry in kv )
            {
                orderCopy[entry.Key] = new Order
                {
                    OrderId = order.OrderId,
                    OrdType = order.OrdType,
                    Price = order.Price,
                    Qty = order.Qty,
                    Symbol = order.Symbol,
                    Side = order.Side,
                    TimeInForce = order.TimeInForce,
                    LeavesQty = order.LeavesQty,
                    FillQty = order.FillQty,
                    OrdStatus = order.OrdStatus,
                    TrdMatchID = order.TrdMatchID
                };
            }
            order.History.Add(orderCopy);
        }

        private void FilterSelection(Dictionary<string, Account> Accounts)
        {
            string filterAccount = combo_acc.SelectedItem?.ToString();
            string filterOrderID = combo_ordID.SelectedItem?.ToString();


            if( string.IsNullOrEmpty(filterAccount) && string.IsNullOrEmpty(filterOrderID) )
            {
                MessageBox.Show("Please select a filter");
                return;
            }
            else if( !string.IsNullOrEmpty(filterAccount) && string.IsNullOrEmpty(filterOrderID) )
            {
                //account secili
                grid.Rows.Clear();

                foreach( var order in Accounts[filterAccount].Orders )
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(grid, order.Value.OrderId, filterAccount, $"{OrdTypeToStr[order.Value.OrdType]}({order.Value.OrdType})", $"{OrdStatusToStr[order.Value.OrdStatus]}({order.Value.OrdStatus})", order.Value.TrdMatchID, order.Value.Side, order.Value.Qty, order.Value.Price, order.Value.Symbol, order.Value.TimeInForce, order.Value.LeavesQty, btn_history);
                    grid.Rows.Add(row);
                }
            }
            else if( string.IsNullOrEmpty(filterAccount) && !string.IsNullOrEmpty(filterOrderID) )
            {
                //orderid secili
                grid.Rows.Clear();


                foreach( var account in Accounts )
                {
                    var order = account.Value.Orders.FirstOrDefault(o => o.Value.OrderId == filterOrderID);
                    if( order.Value != null )
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(grid, order.Value.OrderId, account.Value.AccountID, $"{OrdTypeToStr[order.Value.OrdType]}({order.Value.OrdType})", $"{OrdStatusToStr[order.Value.OrdStatus]}({order.Value.OrdStatus})", order.Value.TrdMatchID, order.Value.Side, order.Value.Qty, order.Value.Price, order.Value.Symbol, order.Value.TimeInForce, order.Value.LeavesQty, btn_history);
                        grid.Rows.Add(row);
                    }
                }
            }
            else
            {
                //hem account hem orderid secili
                grid.Rows.Clear();

                foreach( var account in Accounts )
                {
                    var order = account.Value.Orders.FirstOrDefault(o => o.Value.OrderId == filterOrderID && account.Value.AccountID == filterAccount);
                    if( order.Value != null )
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(grid, order.Value.OrderId, account.Value.AccountID, $"{OrdTypeToStr[order.Value.OrdType]}({order.Value.OrdType})", $"{OrdStatusToStr[order.Value.OrdStatus]}({order.Value.OrdStatus})", order.Value.TrdMatchID, order.Value.Side, order.Value.Qty, order.Value.Price, order.Value.Symbol, order.Value.TimeInForce, order.Value.LeavesQty, btn_history);
                        grid.Rows.Add(row);
                    }
                }
            }
        }

        private void ClearSelection()
        {
            grid.Rows.Clear();
            combo_acc.Items.Clear();
            combo_acc.SelectedIndex = -1;
            combo_acc.Text = "";
            combo_ordID.Items.Clear();
            combo_ordID.SelectedIndex = -1;
            combo_ordID.Text = "";

            foreach( var account in Accounts.Values )
            {
                foreach( var order in account.Orders.Values )
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(grid, order.OrderId, account.AccountID, $"{OrdTypeToStr[order.OrdType]}({order.OrdType})", $"{OrdStatusToStr[order.OrdStatus]}({order.OrdStatus})", order.TrdMatchID, order.Side, order.Qty, order.Price, order.Symbol, order.TimeInForce, order.LeavesQty, btn_history);
                    grid.Rows.Add(row);
                }
            }
            FillControls(Accounts);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterSelection(Accounts);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void combo_acc_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_ordID.Items.Clear();
            combo_ordID.SelectedIndex = -1;
            combo_ordID.Text = "";


            string selectedAccount = combo_acc.SelectedItem?.ToString();
            if( !string.IsNullOrEmpty(selectedAccount) )
            {
                foreach( var account in Accounts )
                {
                    if( account.Key == selectedAccount )
                    {
                        foreach( var order in account.Value.Orders )
                        {
                            combo_ordID.Items.Add(order.Key);
                        }
                        break;
                    }
                }
            }


        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if( e.ColumnIndex == Col_History.Index && e.RowIndex >= 0 )
            {
                string orderId = grid.Rows[e.RowIndex].Cells["Col_ordID"].Value.ToString();
                DisplayOrderHistory(orderId);
            }
        }

        private void DisplayOrderHistory(string orderId)
        {
            grid2.Rows.Clear(); // Grid2'yi temizle

            foreach( var account in Accounts.Values )
            {
                foreach( var order in account.Orders.Values )
                {
                    if( order.OrderId == orderId )
                    {
                        int idx = 0;
                        Order prev = null;
                        foreach( var history in order.History )
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            var ordStatus = $"{OrdStatusToStr[history["39"].OrdStatus]}({history["39"].OrdStatus})";

                            var TrdMatchID = "";
                            if( !history.ContainsKey("41") && (history["39"].OrdStatus == '1' || history["39"].OrdStatus == '2') )
                            {
                                TrdMatchID = history["880"].TrdMatchID.ToString();
                            }

                            if( history["39"].OrdStatus == '4' )
                            {
                                string ordType = prev == null ? "" : prev.OrdType.ToString();
                                string price = prev == null ? "" : prev.Price.ToString();
                                string timeInForce = prev == null ? "" : prev.TimeInForce.ToString();
                                
                                if(!string.IsNullOrEmpty(ordType))
                                    ordType= $"{OrdTypeToStr[ordType[0]]}({ordType[0]})";

                                row.CreateCells(grid2, history["37"].OrderId, account.AccountID, ordType, ordStatus, TrdMatchID, history["54"].Side, history["38"].Qty, price, history["55"].Symbol, timeInForce, history["151"].LeavesQty, history["14"].FillQty, btn_history);
                                grid2.Rows.Add(row);
                                ++idx;
                                continue;
                            }

                            var orderType = $"{OrdTypeToStr[history["40"].OrdType]}({history["40"].OrdType})";

                            prev = history["9"];

                            if( history.ContainsKey("14") )
                                row.CreateCells(grid2, history["37"].OrderId, account.AccountID, orderType, ordStatus, TrdMatchID, history["54"].Side, history["38"].Qty, history["44"].Price, history["55"].Symbol, history["59"].TimeInForce, history["151"].LeavesQty, history["14"].FillQty, btn_history);
                            else
                                row.CreateCells(grid2, history["37"].OrderId, account.AccountID, orderType, ordStatus, TrdMatchID, history["54"].Side, history["38"].Qty, history["44"].Price, history["55"].Symbol, history["59"].TimeInForce, history["151"].LeavesQty, " ", btn_history);
                            grid2.Rows.Add(row);

                            ++idx;
                        }
                    }
                }
            }

            tabControl1.SelectedIndex = 1;
        }
    }
}
