using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. Nome é obrigatório");
            DomainExceptionValidation.When(name.Length < 3, "Nome curto, é necessário no minimo 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Nome inválido. Nome é obrigatório");
            DomainExceptionValidation.When(description.Length < 5, "Nome curto, é necessário no minimo 3 caracteres");
            DomainExceptionValidation.When(price < 0, "Preço não pode ser negativo");
            DomainExceptionValidation.When(stock < 0, "Nome curto, é necessário no minimo 3 caracteres");
            DomainExceptionValidation.When(image?.Length > 250, "Nome inválido para imagem, maximo 250 caracteres");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

    }
}
