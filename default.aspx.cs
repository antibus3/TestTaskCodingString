using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeGeneration;
using System.Text.RegularExpressions;

namespace TestTaskCodingString
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //  Метод события кодирования данных
        protected void CodingButton_Click(object sender, EventArgs e)
        {
            try
            {
                CodingString.Text = "";
                Dictionary<int, string> ListObjectFull = (Dictionary<int, string>)Session["ListObject"];
                if (!ValidationCreate(ListObjectFull)) return;
                string nameID = NameIDSelect.SelectedValue;
                string personalAccount = PersonalAccount.Text;
                DateTime dateTime = Calendar.SelectedDate;
                ObjectOfConsumption objectOfConsumption = new ObjectOfConsumption(nameID, personalAccount, dateTime);
                string code;
                if (ChoiceGenerator.SelectedValue == "Алгоритм 1")

                    code = Coding.CodingGenerator1(objectOfConsumption);
                else
                    code = Coding.CodingGenerator2(objectOfConsumption);
                CodingString.Text = code;
                //  Добавление истории кодировки
                List<string> historyList = (List<string>)Session["History"];
                string nameObject = ListObjectFull[Convert.ToInt32(objectOfConsumption.nameID)];
                string record = code + " - имя: " + nameObject + " " + personalAccount + " " + dateTime.ToShortDateString();
                historyList.Add(record);
                Session["History"] = historyList;
            }catch(Exception ex)
            {
                GlobalError.Text = ex.Message;
            }
        }

        //  Метод добавления нового объекта
        protected void InputObjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                //  Выгрузить колекцию объектов из сессии обновить и добавить обратно
                Dictionary<int, string> ListObjectFull = (Dictionary<int, string>)Session["ListObject"];
                ListObjectFull.Add(ListObjectFull.Keys.Max() + 1, InputNameObject.Text);
                Session["ListObject"] = ListObjectFull;
            }catch(Exception ex)
            {
                GlobalError.Text = ex.Message;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {
                //  Выгрузка из сессии списка с объектами
                Dictionary<int, string> ListObjectFull = (Dictionary<int, string>)Session["ListObject"];
                ListObject.Items.Clear();
                int NameIDSelectItem = NameIDSelect.SelectedIndex;
                NameIDSelect.Items.Clear();
                foreach (int i in ListObjectFull.Keys)
                {

                    ListItem listItem = new ListItem(ListObjectFull[i], i.ToString());
                    //  Заполнить список известных объектов
                    ListObject.Items.Add(listItem);

                    // Записать все имена объектов в поле выбора объекта
                    NameIDSelect.Items.Add(listItem);
                }
                // возвратить выбранный итем
                NameIDSelect.SelectedIndex = NameIDSelectItem;

                if (!IsPostBack)
                {
                    NameIDSelect.SelectedIndex = 0;
                    Calendar.SelectedDate = DateTime.Now;
                    Session["History"] = new List<string>();
                }

                //  Вывести лист кодировок
                List<string> historyList = (List<string>)Session["History"];
                HistoryCodingList.Items.Clear();
                foreach (string record in historyList)
                {
                    HistoryCodingList.Items.Add(record);
                }
            }catch (Exception ex)
            {
                GlobalError.Text = ex.Message;
            }

        }

        //  Метод проверки полей ввода данных
        private bool ValidationCreate (Dictionary<int, string> ListObjectFull)
        {
            //  Проверка введёной даты
            if ((Calendar.SelectedDate > new DateTime(2099, 12, 31)) || (Calendar.SelectedDate < new DateTime(2000, 1, 1)))
            {
                DataError.Visible = true;
                return false;
            }
            else DataError.Visible = false;

            Regex regex = new Regex("^([0-9]{8})$");
            //  Проверка достоверности принятых данных
            if (PersonalAccount.Text == "" || !regex.IsMatch(PersonalAccount.Text)) return false;
            try
            {
                if (!ListObjectFull.ContainsKey(Convert.ToInt16(NameIDSelect.SelectedValue))) return false;
            }catch (Exception ex)
            {
                GlobalError.Text = ex.Message;
            }
            return true;
        }

        // Событие декодирования 
        protected void DecodingButton_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<int, string> ListObjectFull = (Dictionary<int, string>)Session["ListObject"];
                ObjectFiled.Visible = false;
                string trimmstring = DecodingString.Text.Trim(' ');
                if (!ValidationInput(trimmstring)) return;
                ObjectOfConsumption objectOfConsumption;
                //  Выбор декодера и декодирование строки
                if (trimmstring[0] == 'a')
                    objectOfConsumption = Decoding.DecodingGenerator1(trimmstring);
                else
                    objectOfConsumption = Decoding.DecodingGenerator2(trimmstring);
                //  Заполнение полей
                try
                {
                    NameObjectInput.Text = ListObjectFull[Convert.ToInt32(objectOfConsumption.nameID)];
                }catch
                {
                    ObjectFiled.Visible = true;
                    return;
                }
                PersonalAccountInput.Text = objectOfConsumption.personalAccount;
                DateInput.Text = objectOfConsumption.dateTime.ToShortDateString();
            }catch (Exception ex)
            {
                GlobalError.Text = ex.Message;
            }
        }

        //  Метод, проверяющий строку декодирования на соответствия
        private bool ValidationInput (string trimmstring)
        {
            //  Проверка на длину входной строки
            if (!(trimmstring.Length == 18 || trimmstring.Length == 10))
            {
                DecodingError.Visible = true;
                return false;
            }
            else 
            //  проверка на наличие метки типа кодера
                if (!(trimmstring[0] != 'a' || trimmstring[0] != 'b'))
                {
                    DecodingError.Visible = true;
                    return false;
                }
            DecodingError.Visible = false;
            return true;
        }
    }
}