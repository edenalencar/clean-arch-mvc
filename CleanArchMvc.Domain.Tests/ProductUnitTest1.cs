using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Criar Produto com nome válido")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, 99, "product image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Produto com valor inválido")]
        public void CreateProduct_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Product(-1, "Pro", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Id inválido");
        }

        [Fact(DisplayName = "Criar Produto com nome curto")]
        public void CreateProduct_ShortName_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome curto, é necessário no minimo 3 caracteres");
        }

        [Fact(DisplayName = "Criar Produto com nome da imagem longo")]
        public void CreateProduct_LongImageValue_DomainExceptionRequeridName()
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, 99, "produto image tooooooooooooooooooooooooooooooooo lonooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooosssssssssssssfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffoooooog");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome inválido para imagem, maximo 250 caracteres");
        }

        [Fact(DisplayName = "Criar Produto com preço inválido")]
        public void CreateProduct_PriceValueInvalid_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Pro", "Product Description", -1, 99, "produto image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Preço não pode ser negativo");
        }

        [Fact(DisplayName = "Criar Produto com nome de imagem null")]
        public void CreateProduct_WithNullImageName_NotNullReferenceException()
        {
            Action action = () => new Product(1, "Pro", "Product Description", -1, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Theory(DisplayName = "Criar Produto com nome nulo")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue( int value)
        {
            Action action = () => new Product(1, "Pro","Product Description",9.99m, value, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome curto, é necessário no minimo 3 caracteres");
        }
    }
}
