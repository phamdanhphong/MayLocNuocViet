namespace  Fsoft.SKU.CoreApp.Services.Searchs
{
    public class ParamSearchUser
    {
        private int _pageIndex;

        public ParamSearchUser()
        {
            PageIndex = 1;
            PageSize = 20;
            //SortOrder = SortEnum.SortOrder.ASC.ToString();
            //SortField = UserSortField.FirstName.ToString();
        }

        public string Keyword { get; set; }
        public string RoleId { get; set; }
        public int? UserStatus { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }

        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value > 0 ? value : 1; }
        }

        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsOnlySearchGuest { get; set; }
    }
}