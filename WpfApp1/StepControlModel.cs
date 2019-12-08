using Pandap.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    public class Step : MyBindableBase
    {
        private string ısColored;

        public bool IsActive { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public string OnayDurum { get => ısColored; set => SetProperty(ref ısColored ,value); }
        public int LineHeight { get; internal set; }
        public string LeftData { get; internal set; }
        public string RightData { get; internal set; }
    }
    public class StepControlModel : MyBindableBase
    {
        private ObservableCollection<Step> steps;
        private Step selectedStep;

        public ObservableCollection<Step> Steps { get => steps; set => SetProperty(ref steps, value); }

        public Step SelectedStep
        {
            get => selectedStep;
            set
            {
                SetProperty(ref selectedStep, value);

                Steps.Where(c => c.Index <= value.Index).ToList().ForEach(c => { c.OnayDurum = "Onaylandı"; });

                Steps.Where(c => c.Index > value.Index).ToList().ForEach(c => { c.OnayDurum = "Onaylanacak"; });

                value.OnayDurum = "Onayda";

                //Steps[0].OnayDurum = "Başladı";

                //Steps[Steps.Count-1].OnayDurum = "Bitti";




            }
        }

        public void Next()
        {
            var index = SelectedStep.Index +1;
            if (index+1 > Steps.Count) index = Steps.Count-1;

            SelectedStep = Steps[index];
        }

        public void Previous()
        {
            var index = SelectedStep.Index - 1;
            if (index < 0) index = 0;

            SelectedStep = Steps[index];
        }
        public StepControlModel()
        {
           

            Steps = new ObservableCollection<Step>();
            Step s1 = new Step { IsActive = false, RightData = "Talep Oluşturuldu", Index = 0, 
                 LineHeight=10,LeftData="12.10.2019"};

            Step s2 = new Step { IsActive = true, RightData = "Yönetici Önayı", Index =1, 
                 LineHeight=50,LeftData="14.12.2019"};

            Step s3 = new Step { IsActive = false, RightData = "Satın Alma", Index = 2, 
                 LineHeight = 50 };

            Step s4 = new Step { IsActive = false, RightData = "Muhasebe", Index = 3, 
                 LineHeight = 50 };

          

            Steps.Add(s1);
            Steps.Add(s2);
            Steps.Add(s3);
            Steps.Add(s4);


            SelectedStep = s2;
        }
    }
}
