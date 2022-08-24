namespace EFCoreDatabaseFirstSample.DTOs
{
    public class AuthorDto
    {
        public AuthorDto()
        {
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public AuthorContactDto AuthorContact { get; set; }
    }
    public static class AuthorDtoMapper
    {
        public static AuthorDto MapToDto(Author author)
        {
            return new AuthorDto()
            {
                Id = author.Id,
                Name = author.Name,
                AuthorContact = new AuthorContactDto()
                {
                    AuthorId = author.Id,
                    Address = author.AuthorContact.Address,
                    ContactNumber = author.AuthorContact.ContactNumber,
                    Email = author.AuthorContact.Email
                }
            };
        }
    }
}
