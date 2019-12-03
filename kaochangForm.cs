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
    public partial class kaochangForm : Form
    {
        public kaochangForm()
        {
            InitializeComponent();
        }

        public int varID; //全局变量 传修改某项的ID



        private void kaochangForm_Load(object sender, EventArgs e)
        {
            showAll();
        }
        /// <summary>
        /// 在CheckListBox中显示所有考场
        /// </summary>
        private void showAll()
        {
            #region 先清空CheckListBox列表
            for (int i = 0; i < ckListBoxCydw.Items.Count; i++)
            {
                ckListBoxCydw.Items.Clear();
            }
            #endregion
            db_kaochang manage = new db_kaochang();
            DataTable dtList = manage.GetList(" examnameid='" + publicModel.examName + "'").Tables[0];
            for (int i = 0; i < dtList.Rows.Count; i++)
            {
                ckListBoxCydw.Items.Insert(i, dtList.Rows[i]["kcName"].ToString());
            }
        }
        //新增
        private void btn_Save_Click(object sender, EventArgs e)
        {
            db_kaochang manage = new db_kaochang();
            if (!manage.Exists(txtKCMC.Text.Trim(),publicModel.examName) && !string.IsNullOrEmpty(txtKCMC.Text.Trim()))
            {
                try
                {
                    manage.kcName = txtKCMC.Text.ToString().Trim();
                    manage.examNameID = publicModel.examName;
                    manage.remark = "";
                    manage.Add();

                    DialogResult dialogres = MessageBox.Show("添加考场名称成功！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (dialogres == DialogResult.OK)
                    {
                        showAll();
                        txtKCMC.Text = String.Empty;
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
            db_kaochang manage = new db_kaochang();
            string name = txtKCMC.Text.Trim();
            manage.ID = varID;
            manage.kcName = name;
            manage.examNameID = publicModel.examName;
            manage.remark = "";
            if (manage.Update())
            {
                MessageBox.Show("修改考场名称成功！");
                showAll();
                txtKCMC.Text = String.Empty;
            }
            else
                MessageBox.Show("操作失败！");
        }
        //删除
        private void btn_Del_Click(object sender, EventArgs e)
        {
            db_kaochang manage = new db_kaochang();
            string idString = "";
            for (int i = 0; i < ckListBoxCydw.CheckedItems.Count; i++)
            {
                string name = ckListBoxCydw.GetItemText(ckListBoxCydw.CheckedItems[i]);
                string id = new db_kaochang(name).ID.ToString();
                idString += id + ",";
            }
            if (!string.IsNullOrEmpty(idString))
            {
                if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (manage.DeleteList(idString.Remove(idString.Length - 1)))
                    {
                        showAll();
                        MessageBox.Show("成功删除" + idString.Remove(idString.Length - 1).Split(',').Length + "个考场！");
                        txtKCMC.Text = String.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择考场再点删除");
            }
        }
        //单击checkListBox的项
        private void ckListBoxCydw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ckListBoxCydw.SelectedItem != null)
            {
                string name = ckListBoxCydw.SelectedItem.ToString();
                db_kaochang manage = new db_kaochang(name);
                varID = manage.ID;
                txtKCMC.Text = name;

            }
        }
    }
}
