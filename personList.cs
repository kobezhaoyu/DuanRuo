using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CVR100A_U_DSDK_Demo.App_Code;
using System.Threading;

namespace CVR100A_U_DSDK_Demo
{
    public partial class personList : Form
    {
        private delegate void FlushClient();//代理

        public personList()
        {
            InitializeComponent();
        }

        db_students studentsModel = new db_students();

        private void personList_Load(object sender, EventArgs e)
        {
            BindCmbKSMC();
            DataTable dtStudents = studentsModel.GetList(combSql()).Tables[0];
            dgvList.DataSource = dtStudents;

            TitleDgvBillList();

        }

        /// <summary>
        /// 绑定考试名称
        /// </summary>
        private void BindCmbKSMC()
        {
            DataTable dtDicCydw = new db_examName().GetList("").Tables[0];
            DataRow dr = dtDicCydw.NewRow();
            dr["ID"] = "0";
            dr["examname"] = "--请选择--";
            dtDicCydw.Rows.InsertAt(dr, 0);
            cmbKaoshiName.DisplayMember = "examname";
            cmbKaoshiName.ValueMember = "ID";
            cmbKaoshiName.DataSource = dtDicCydw.DefaultView;


            cmbStatus.Items.Insert(0, "--状态--");
            cmbStatus.Items.Insert(1, "正常");
            cmbStatus.Items.Insert(2, "异常");
            cmbStatus.Items.Insert(3, "未签到");
            cmbStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定DataGridView标题文本
        /// </summary>
        private void TitleDgvBillList()
        {
            dgvList.Columns["ID"].Visible = false;
            dgvList.Columns["ID"].HeaderText = "自增ID";
            dgvList.Columns["prushTime"].HeaderText = "刷卡时间";
            dgvList.Columns["stuNo"].HeaderText = "准考证号";
            dgvList.Columns["stuName"].HeaderText = "姓名";
            dgvList.Columns["sex"].HeaderText = "性别";
            dgvList.Columns["nation"].HeaderText = "民族";
            dgvList.Columns["birthday"].HeaderText = "出生日期";
            dgvList.Columns["IdCard"].HeaderText = "身份证号";
            dgvList.Columns["address"].HeaderText = "地址";
            dgvList.Columns["qianzhengjiguan"].HeaderText = "签发机关";
            dgvList.Columns["youxiaoqixian"].HeaderText = "有效期限";
            dgvList.Columns["status"].HeaderText = "状态";
            dgvList.Columns["applyNo"].HeaderText = "报名序号";
            dgvList.Columns["kaochangName"].HeaderText = "考场名称";
            dgvList.Columns["examNameID"].HeaderText = "考试名称";

            dgvList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //增加序号列
        private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvList.RowHeadersWidth = 50;
            dgvList.TopLeftHeaderCell.Value = "序号";
            SolidBrush b = new SolidBrush(this.dgvList.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvList.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string combSql()
        {
            string strWhere = " id>0 ";//and examNameID='" + publicModel.strValue + "'";
            if (cmbKaoshiName.Text != "--请选择--")
            {
                strWhere += " and examNameID='" + cmbKaoshiName.Text + "'";
            }
            if (cmbStatus.Text != "--状态--")
            {
                strWhere += " and status='" + cmbStatus.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtStuName.Text))
            {
                strWhere += " and stuName like'" + txtStuName.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtIdCard.Text))
            {
                strWhere += " and IdCard like'" + txtIdCard.Text.Trim() + "%'";
            }
            return strWhere;
        }
        private void selModel() {
            string strWhere = combSql();
            DataTable dtStudents = studentsModel.GetList(strWhere).Tables[0];
            dgvList.DataSource = dtStudents;
            TitleDgvBillList();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            selModel();
        }
        //导出Excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            string strWhere = combSql();
            DataTable dtStudents = studentsModel.GetList(strWhere).Tables[0];

            //线程控制
            this.Invoke(new MethodInvoker(delegate
            {
                SaveToExcel();
            }));

        }

        //清除本考试的所有信息
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("点击“确定”按钮后将清除本考试的\n所有学员资料，确定删除吗?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int nums = DbHelperOleDb.ExecuteSql("delete from db_students where examNameID='" + publicModel.examName + "'");
                    if (nums>0)
                    {
                        MessageBox.Show(nums + "条信息已成功清理！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        selModel();
                    }
                    else
                    {
                        MessageBox.Show("已经很干净了！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch
                {

                }
            }
        }


        #region -------------------  废弃  -----------------

        //#region 导出全部数据到Excel中，可弹出保存对话框，但没用SaveFileDialog

        //public void printAll(System.Data.DataTable dt)
        //{
        //    //导出到execl   
        //    try
        //    {
        //        //没有数据的话就不往下执行   
        //        if (dt.Rows.Count == 0)
        //            return;
        //        //实例化一个Excel.Application对象   
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        //        //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错   
        //        excel.Application.Workbooks.Add(true);

        //        //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写   
        //        excel.Visible = false;
        //        //生成Excel中列头名称   
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            excel.Cells[1, i + 1] = dgvList.Columns[i].HeaderText;//输出DataGridView列头名   
        //        }

        //        //把DataGridView当前页的数据保存在Excel中   
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)//控制Excel中行，上下的距离，就是可以到Excel最下的行数，比数据长了报错，比数据短了会显示不完   
        //            {
        //                for (int j = 0; j < dt.Columns.Count; j++)//控制Excel中列，左右的距离，就是可以到Excel最右的列数，比数据长了报错，比数据短了会显示不完   
        //                {
        //                    string str = dt.Rows[i][j].ToString();
        //                    excel.Cells[i + 2, j + 1] = "'" + str;//i控制行，从Excel中第2行开始输出第一行数据，j控制列，从Excel中第1列输出第1列数据，"'" +是以string形式保存，所以遇到数字不会转成16进制   
        //                }
        //            }
        //        }
        //        //设置禁止弹出保存和覆盖的询问提示框   
        //        excel.DisplayAlerts = false;
        //        excel.AlertBeforeOverwriting = false;

        //        //保存工作簿，值为false会报错   
        //        excel.Application.Workbooks.Add(true).Save();
        //        //保存excel文件   
        //        excel.Save("D:" + "\\KKHMD.xls");

        //        //确保Excel进程关闭   
        //        excel.Quit();
        //        excel = null;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "错误提示");
        //    }

        //}

        //#endregion

        //#region 将DataGridView控件中数据导出到Excel
        ///// <summary>
        ///// 将DataGridView控件中数据导出到Excel
        ///// </summary>
        ///// <param name="gridView">DataGridView对象</param>
        ///// <param name="isShowExcle">是否显示Excel界面</param>
        ///// <returns></returns>
        //public bool ExportDataGridview(DataGridView gridView, bool isShowExcle)
        //{
        //    if (gridView.Rows.Count == 0)
        //        return false;
        //    //建立Excel对象
        //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //    excel.Application.Workbooks.Add(true);
        //    excel.Visible = isShowExcle;
        //    //生成字段名称
        //    for (int i = 0; i < gridView.ColumnCount; i++)
        //    {
        //        excel.Cells[1, i + 1] = gridView.Columns[i].HeaderText;
        //    }
        //    //填充数据
        //    for (int i = 0; i < gridView.RowCount - 1; i++)
        //    {
        //        for (int j = 0; j < gridView.ColumnCount; j++)
        //        {
        //            if (gridView[j, i].ValueType == typeof(string))
        //            {
        //                excel.Cells[i + 2, j + 1] = "'" + gridView[j, i].Value.ToString();
        //            }
        //            else
        //            {
        //                excel.Cells[i + 2, j + 1] = gridView[j, i].Value.ToString();
        //            }
        //        }
        //    }
        //    return true;
        //}
        //#endregion

        //#region 将所有数据导出到Excel：
        //private void GenerateExcelAll(System.Data.DataTable dt, DataGridView dgv)
        //{
        //    //导出到execl  
        //    try
        //    {
        //        //没有数据的话就不往下执行  
        //        if (dt.Rows.Count == 0)
        //        {
        //            MessageBox.Show("当前页面没有数据可以导出！", "导出结果", MessageBoxButtons.OK);
        //            return;
        //        }
        //        //实例化一个Excel.Application对象  
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //        //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错  
        //        excel.Application.Workbooks.Add(true);
        //        //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写  
        //        excel.Visible = false;
        //        //生成Excel中列头名称 
        //        //生成Excel中列头名称------------------------------**********************************--------------------------------------- 
        //        int columnCount = 0;
        //        for (int i = 0; i < dgv.Columns.Count; i++)
        //        {
        //            if (dgv.Columns[i].Visible)
        //            {
        //                columnCount = columnCount + 1;
        //            }
        //        }
        //        string[] headers = new string[columnCount];
        //        int index = 0;
        //        for (int i = 0; i < dgv.Columns.Count; i++)
        //        {
        //            if (dgv.Columns[i].Visible)
        //            {
        //                headers[index] = dgv.Columns[i].HeaderText;
        //                index = index + 1;
        //            }
        //        }
        //        for (int i = 0; i < columnCount; i++)
        //        {
        //            excel.Cells[1, i + 1] = headers[i];
        //            //if (dgv.Columns[i].ValueType == typeof(DateTime))
        //            //{
        //            //    Microsoft.Office.Interop.Excel.Range headRange = excel.Cells[1, i - 1] as Microsoft.Office.Interop.Excel.Range;// as Range;//获取表头单元格
        //            //    headRange.ColumnWidth = 22;//设置列宽
        //            //}
        //        }
        //        //---------------------------------------------------**********************************----------------------------------------
        //        ////////----------------------------------------**************************************---------------------------------------------
        //        //把DataGridView当前页的数据保存在Excel中  
        //        if (dt.Rows.Count > 0)
        //        {
        //            int ccc = dgv.Columns.Count;
        //            for (int i = 0; i < dt.Rows.Count; i++)//控制Excel中行，上下的距离，就是可以到Excel最下的行数，比数据长了报错，比数据短了会显示不完  
        //            {
        //                int columnIndex = 0;
        //                for (int j = 0; j < dt.Columns.Count; j++)//控制Excel中列，左右的距离，就是可以到Excel最右的列数，比数据长了报错，比数据短了会显示不完  
        //                {
        //                    if (dgv.Columns[j].Visible)
        //                    {
        //                        columnIndex = columnIndex + 1;
        //                        string str = dt.Rows[i][j].ToString();
        //                        excel.Cells[i + 2, columnIndex] = "'" + str;//i控制行，从Excel中第2行开始输出第一行数据，j控制列，从Excel中第1列输出第1列数据，"'" +是以string形式保存，所以遇到数字不会转成16进制  
        //                    }
        //                }
        //            }
        //        }
        //        //设置禁止弹出保存和覆盖的询问提示框  
        //        excel.DisplayAlerts = false;
        //        excel.AlertBeforeOverwriting = false;
        //        //保存工作簿，值为false会报错  
        //        //excel.Application.Workbooks.Add(false);//.Save();
        //        //确保Excel进程关闭  
        //        excel.Save();
        //        excel.Quit();
        //        excel = null;
        //        MessageBox.Show("您所查询的所有数据已经成功导出到您指定的目录！", "导出结果", MessageBoxButtons.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "错误提示");
        //    }
        //}
        //#endregion

        #endregion

        /// <summary>

        /// 另存新档按钮   导出成Excel

        /// </summary>

        private void SaveToExcel() //另存新档按钮   导出成Excel
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";

            saveFileDialog.FilterIndex = 0;

            saveFileDialog.RestoreDirectory = true;

            saveFileDialog.CreatePrompt = true;

            saveFileDialog.Title = "Export Excel File To";


            saveFileDialog.ShowDialog();

            string strName = saveFileDialog.FileName;

            if (string.IsNullOrEmpty(strName))
            {
                return;
            }

            System.Reflection.Missing miss = System.Reflection.Missing.Value;


            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();

            Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;

            Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));

            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;

            sheet.Name = "test";


            int colIndex = 0;

            foreach (DataGridViewColumn column in dgvList.Columns)
            {

                colIndex++;

                excel.Cells[1, colIndex] = column.HeaderText;

            }


            for (int i = 0; i < dgvList.Rows.Count; i++)
            {

                for (int j = 0; j < dgvList.Columns.Count; j++)
                {
                    if (dgvList.Columns[j].Name == "IdCard")
                        excel.Cells[i + 2, j + 1] = "'"+dgvList.Rows[i].Cells[j].Value.ToString();
                    else
                        excel.Cells[i + 2, j + 1] = dgvList.Rows[i].Cells[j].Value.ToString();

                }

            }



            sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss);



            book.Close(false, miss, miss);

            books.Close();

            excel.Quit();


            //System.Runtime.InteropServices.Marshal.ReleaseComObject();   

            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(book);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(books);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

            GC.Collect();

        }

    }
}