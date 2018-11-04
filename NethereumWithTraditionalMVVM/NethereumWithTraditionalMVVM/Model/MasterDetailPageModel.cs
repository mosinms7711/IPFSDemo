using System;
namespace NethereumWithTraditionalMVVM.Model
{
    public class MasterDetailPageModel
    {
        public MasterDetailPageModel()
        {
            TargetType = typeof(BalancePage);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}
