using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;


namespace whut.stuplaza.UI
{
    public partial class AddColumn : System.Web.UI.Page
    {
        ColumnBLL column = new ColumnBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            }
        }
        protected void column1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<T_stuplazaColumn> list = new List<T_stuplazaColumn>();
            list = column.GetColListByParent(column1.SelectedItem.Text);
            foreach (T_stuplazaColumn col in list)
            {
                ListItem item = new ListItem(col.ColumnName, col.ColumnId);
                column2.Items.Add(item);
            }
            column2.Visible = true;

        }

        protected void txtBtn_Click(object sender, EventArgs e)
        {
            if (colName.Text.ToString().Trim() == "")
            {
                Label1.Text = "(*栏目名不能为空)";
            }
            else
            {
                if (column.GetNameByName(colName.Text.ToString().Trim()))
                {
                    Label1.Visible = true;
                    Label1.Text = "(*栏目名称已经存在，请重新输入栏目)";
                    colName.Text = "";
                }
                else
                {
                    string columnId = GetColId();
                    if (columnId.ToString().Substring(0, 2) == "00")
                    {
                        Label1.Visible = true;
                        Label1.Text = "(*未选择父栏目，请选择)";
                    }
                    else
                    {
                        string name = colName.Text;
                        int status = 0;
                        string content = colContent.Text;
                        if (colDynamic.Checked)
                        {
                            status = 1;
                            content = "";
                        }
                        try
                        {
                            T_stuplazaColumn model = new T_stuplazaColumn();
                            model.ColumnId = GetColId();
                            model.ColumnName = name;
                            model.ColumnStatus = status;
                            model.ColumnContent = content;
                            model.ColumnParent = GetParentNode();
                            model.ColumnDelStatus = 0;
                            if (column.InsertColumn(model) >= 0)
                            {
                                Response.Redirect("ShowColumn.aspx");
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 构造出栏目编号
        /// </summary>
        /// <returns></returns>
        public string GetColId()
        {
            string str = "";
            if (column2.SelectedIndex == 0)
                str += column1.SelectedIndex.ToString("d2") + (column.GetRecordByParent(column1.SelectedItem.ToString())+1).ToString("d2") + "0000";
            else
            {
                if (column3.SelectedIndex == 0)
                    str += column1.SelectedIndex.ToString("d2") + column2.SelectedIndex.ToString("d2") + (column.GetRecordByParent(column2.SelectedItem.ToString().ToString()) + 1).ToString("d2") + "00";
                else
                {
                    str += column1.SelectedIndex.ToString("d2") + column2.SelectedIndex.ToString("d2") + column3.SelectedIndex.ToString("d2") + (column.GetRecordByParent(column3.SelectedItem.ToString()) + 1).ToString("d2");

                }
            }
            return str;
        }


        public string GetParentNode()
        {
            string str = "";
            if (column2.SelectedIndex == 0)
                str = column1.SelectedItem.Text;
            else
            {
                if (column3.SelectedIndex == 0)
                    str = column2.SelectedItem.Text;
                else
                    str = column3.SelectedItem.Text;
            }
            return str;

        }

        protected void column2_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<T_stuplazaColumn> list = column.GetColListByParent(column2.SelectedItem.Text);
            foreach (T_stuplazaColumn col in list)
            {
                ListItem item = new ListItem(col.ColumnName, col.ColumnId);
                column3.Items.Add(item);
            }
            column3.Visible = true;
        }

        protected void column3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<T_stuplazaColumn> list = column.GetColListByParent(column3.SelectedItem.Text);
            foreach (T_stuplazaColumn col in list)
            {
                ListItem item = new ListItem(col.ColumnName, col.ColumnId);
                column4.Items.Add(item);
            }
            column4.Visible = true;
        }

        
    }
}