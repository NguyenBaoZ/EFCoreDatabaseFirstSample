namespace EFCoreDatabaseFirstSample.DTOs
{
    public class AuthorContactDto
    {
        public AuthorContactDto()
        {
        }
        public long AuthorId { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public AuthorDto Author { get; set; }
        public static class AuthorContactDtoMapper
        {
            public static AuthorContactDto MapToDto(AuthorContact authorContact)
            {
                return new AuthorContactDto()
                {
                    AuthorId = authorContact.AuthorId,
                    ContactNumber = authorContact.ContactNumber,
                    Address = authorContact.Address,
                    Email = authorContact.Email,
                    Author = new AuthorDto()
                    {
                        Id = authorContact.Author.Id,
                        Name = authorContact.Author.Name,
                    }
                 };
            }
        }
    }
}
