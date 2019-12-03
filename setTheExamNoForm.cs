using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CVR100A_U_DSDK_Demo.App_Code;

namespace CVR100A_U_DSDK_Demo
{
    public partial class setTheExamNoForm : Form
    {
        public setTheExamNoForm()
        {
            InitializeComponent();
        }

        int varID = 0; //全局变量 传修改某项的ID

        private void setTheExamForm_Load(object sender, EventArgs e)
        {
            BindCmbKCMC();
            //showAll("");
        }

        /// <summary>
        /// 绑定考场
        /// </summary>
        private void BindCmbKCMC()
        {
            DataTable dtDicCydw = new db_kaochang().GetList(" examnameid='" + publicModel.examName + "'").Tables[0];
            DataRow dr = dtDicCydw.NewRow();
            dr["ID"] = "0";
            dr["kcName"] = "--请选择--";
            dtDicCydw.Rows.InsertAt(dr, 0);
            cmbKaochang.DisplayMember = "kcName";
            cmbKaochang.ValueMember = "ID";
            cmbKaochang.DataSource = dtDicCydw.DefaultView;

        }
        /// <summary>
        /// 在CheckListBox中显示某个考场的考号组
        /// </summary>
        /// <param name="kcName">考场名称</param>
        private void showAll(string kcName)
        {
            #region 先清空listBox1列表
            if (listBox1.Items.Count > 0)
            {
                listBox1.DataSource = null;
                listBox1.Items.Clear();
            }
            #endregion
            db_theExamNo manage = new db_theExamNo();
            string strWhere = "";
            if (kcName == "")
                strWhere = "id>0 order by id desc";
            else
                strWhere = "kaochangname='" + kcName + "' order by id desc";
            DataTable dtList = manage.GetList(strWhere).Tables[0];
            listBox1.DataSource = dtList.DefaultView;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "remark";
            listBox1.SelectedIndex = -1;
        }
        //新增
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (cmbKaochang.Text == "--请选择--")
            {
                MessageBox.Show("请选择考场！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(txtStart.Text.Trim()) || string.IsNullOrEmpty(txtEnd.Text.Trim()))
            {
                MessageBox.Show("起始、终止序号不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                db_theExamNo theExam = new db_theExamNo();
                try
                {
                    theExam.kaochangName = cmbKaochang.Text;
                    theExam.startNum = Convert.ToInt32(txtStart.Text.Trim());
                    theExam.endNum = Convert.ToInt32(txtEnd.Text.Trim());
                    theExam.remark = theExam.startNum + "-" + theExam.endNum;
                    theExam.Add();

                    DialogResult dialogres = MessageBox.Show("添加考号成功！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (dialogres == DialogResult.OK)
                    {
                        BindCmbKCMC();
                        txtStart.Text = String.Empty;
                        txtEnd.Text = String.Empty;
                        showAll(cmbKaochang.Text);
                        varID = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //修改
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (varID == 0)
            {
                MessageBox.Show("请选中要修改的项！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                db_theExamNo theExam = new db_theExamNo();
                theExam.ID = varID;
                theExam.kaochangName = cmbKaochang.Text;
                theExam.startNum = Convert.ToInt32(txtStart.Text.Trim());
                theExam.endNum = Convert.ToInt32(txtEnd.Text.Trim());
                theExam.remark = theExam.startNum + "-" + theExam.endNum;

                if (theExam.Update())
                {
                    MessageBox.Show("修改考场成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //showAll();
                    //txtKCMC.Text = String.Empty;
                }
                else
                    MessageBox.Show("操作失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //删除
        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (varID == 0)
            {
                MessageBox.Show("请选中要删除的项！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("确定删除?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db_theExamNo theExam = new db_theExamNo();
                    if (varID > 0)
                    {
                        if (theExam.Delete(varID))
                        {
                            //showAll();
                            MessageBox.Show("成功删除！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtStart.Text = String.Empty;
                            txtEnd.Text = String.Empty;
                            //txtKCMC.Text = String.Empty;
                        }
                    }
                    else
                        MessageBox.Show("请选择考场再点删除", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cmbKaochang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStart.Text = String.Empty;
            txtEnd.Text = String.Empty;
            showAll(cmbKaochang.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                string name = ((System.Data.DataRowView)(listBox1.SelectedItem)).Row.ItemArray[4].ToString();
                string[] stringArray = name.Split('-');
                txtStart.Text = stringArray[0].ToString();
                txtEnd.Text = stringArray[1].ToString();
                varID = Convert.ToInt32(listBox1.SelectedValue.ToString());
                //MessageBox.Show(listBox1.SelectedValue.ToString());
            }
        }


    }
}
