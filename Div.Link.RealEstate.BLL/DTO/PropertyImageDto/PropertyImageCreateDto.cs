namespace Div.Link.RealEstate.BLL.DTO.PropertyImageDto
{
    public class PropertyImageCreateDto
    {
        public string ImageUrl { get; set; }
        public int SortOrder { get; set; } = 0;
        public bool IsMain { get; set; } = false;
    }

}