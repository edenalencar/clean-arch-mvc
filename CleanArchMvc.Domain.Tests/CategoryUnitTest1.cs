using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Criar Categoria com nome válido")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Categoria com valor inválido")]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Id inválido");
        }

        [Fact(DisplayName = "Criar Categoria com nome curto")]
        public void CreateCategory_ShortName_DomainExceptionShortNamme()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome curto, é necessário no minimo 3 caracteres");
        }

        [Fact(DisplayName = "Criar Categoria com nome em branco")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequeridName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome inválido. Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar Categoria com nome nulo")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome inválido. Nome é obrigatório");
        }
    }
}