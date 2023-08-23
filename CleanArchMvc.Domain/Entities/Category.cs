using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);

        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido");
            Id = id;
            ValidateDomain(name);
        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. Nome é obrigatório");
            DomainExceptionValidation.When(name.Length < 3, "Nome curto, é necessário no minimo 3 caracteres");
            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
    }
}
