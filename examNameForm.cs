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
    public partial class examNameForm : Form
    {
        public examNameForm()
        {
            InitializeComponent();
        }

        public int varID; //全局变量 传修改某项的ID


        private void examNameForm_Load(object sender, EventArgs e)
        {
            showAll();
        }
        /// <summary>
        /// 在CheckListBox中显示所有考场
        /// </summary>
        private void showAll()
        {
            #region 先清空CheckListBox列表
            for (int i = 0; i < ckListBoxName.Items.Count; i++)
            {
                ckListBoxName.Items.Clear();
            }
            #endregion
            db_examName manage = new db_examName();
            DataTable dtList = manage.GetList("").Tables[0];
            for (int i = 0; i < dtList.Rows.Count; i++)
            {
                ckListBoxName.Items.Insert(i, dtList.Rows[i]["examName"].ToString());
            }
        }
        //新增
        private void btn_Save_Click(object sender, EventArgs e)
        {
            db_examName manage = new db_examName();
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请输入考试名称！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!manage.Exists(txtName.Text.Trim()))
                {
                    try
                    {
                        manage.examName = txtName.Text.ToString().Trim();
                        manage.Add();

                        DialogResult dialogres = MessageBox.Show("添加考试名称成功！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (dialogres == DialogResult.OK)
                        {
                            showAll();
                            txtName.Text = String.Empty;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("此考试名称已存在，请换个名称！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        //修改
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            db_examName manage = new db_examName();
            string name = txtName.Text.Trim();
            manage.ID = varID;
            manage.examName = name;
            if (manage.Update())
            {
                MessageBox.Show("修改考试名称成功！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                showAll();
                txtName.Text = String.Empty;
            }
            else
                MessageBox.Show("操作失败！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //删除
        private void btn_Del_Click(object sender, EventArgs e)
        {
            db_examName manage = new db_examName();
            string idString = "";
            for (int i = 0; i < ckListBoxName.CheckedItems.Count; i++)
            {
                string name = ckListBoxName.GetItemText(ckListBoxName.CheckedItems[i]);
                string id = new db_examName(name).ID.ToString();
                idString += id + ",";
            }
            if (!string.IsNullOrEmpty(idString))
            {
                if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (manage.DeleteList(idString.Remove(idString.Length - 1)))
                    {
                        showAll();
                        MessageBox.Show("成功删除" + idString.Remove(idString.Length - 1).Split(',').Length + "个考试名称！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtName.Text = String.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择考试名称再点删除", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //单击checkListBox的项
        private void ckListBoxCydw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ckListBoxName.SelectedItem != null)
            {
                string name = ckListBoxName.SelectedItem.ToString();
                db_examName manage = new db_examName(name);
                varID = manage.ID;
                txtName.Text = name;

            }
        }

    }
}
