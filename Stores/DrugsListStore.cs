using Drugstore_Application.Model;
using Drugstore_Application.Model.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Stores
{
    public class DrugsListStore : PropertyChange
    {
        private ObservableCollection<Drug> _drugsList;
        public int CurDrugId = 0;

        public ObservableCollection<Drug> DrugsList { get => _drugsList; set {  _drugsList = value; OnDrugsListChanged(); } }

        public DrugsListStore ()
        {
            DrugsList = new ObservableCollection<Drug>
            {
                new(CurDrugId, "Циклоферон 150 мг таблетки 20 шт", "Грипп и острые респираторные заболевания, герпетическая инфекция", 35, 589, 245),
                new(CurDrugId + 1, "Золотая звезда бальзам мазь д/нар. прим.", "Головная боль, головокружение, насморк, укусы насекомых", 15, 179, 89),
                new(CurDrugId + 2, "Стрепсилс таб. д/рассас., 24 шт., лимон+мед", "Болевой синдром воспалительных заболеваний полости рта и ЛОР-органов, " +
                "боль в горле, инфекционно-воспалительные заболевания полости рта и глотки, ларингит, тонзиллит, фарингит", 7, 238, 119),
                new(CurDrugId + 3, "Уголь активированный таб., 250 мг, 20 шт.", "Диспепсические явления, лечение пищевых токсикоинфекций (ПТИ), энтеросорбирующее" +
                " средство для дезинтоксикации при экзо и эндогенных интоксикациях", 23, 34, 17),
                new(CurDrugId + 4, "Тантум верде спрей д/мест. прим. дозир., 0.255 мг/доза, 30 мл", "Болевой синдром воспалительных заболеваний полости рта и ЛОР-органов," +
                " гингивит, глоссит, инфекционно-воспалительные заболевания полости рта и глотки, калькулезное воспаление слюнных желез, кандидоз слизистой оболочки полости рта," +
                " ларингит, пародонтоз, после лечения и удаления зубов, стоматит, тонзиллит, фарингит", 27, 459, 229),
                 new(CurDrugId + 5, "Но-шпа таб., 40 мг, 64 шт.", "Головная боль, желудочно-кишечные спазмы, колит, первичная дисменорея, холангит, холецистит, цистит, энтероколит," +
                 " язвенная болезнь желудка и двенадцатиперстной кишки", 17, 393, 196),
            };
            CurDrugId += 5;
        }

        public event Action DrugsListChanged;

        private void OnDrugsListChanged()
        {
            DrugsListChanged?.Invoke();
        }
    }
}
