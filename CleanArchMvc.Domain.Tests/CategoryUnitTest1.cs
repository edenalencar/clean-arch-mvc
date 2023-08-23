using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Criar Categoria com nome v�lido")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Categoria com valor inv�lido")]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Id inv�lido");
        }

        [Fact(DisplayName = "Criar Categoria com nome curto")]
        public void CreateCategory_ShortName_DomainExceptionShortNamme()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome curto, � necess�rio no minimo 3 caracteres");
        }

        [Fact(DisplayName = "Criar Categoria com nome em branco")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequeridName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome inv�lido. Nome � obrigat�rio");
        }

        [Fact(DisplayName = "Criar Categoria com nome nulo")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Nome inv�lido. Nome � obrigat�rio");
        }
    }
}