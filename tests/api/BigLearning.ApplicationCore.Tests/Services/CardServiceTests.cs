using Ardalis.Specification;
using AutoFixture;
using Elang.ApplicationCore.Cards.Dto;
using Elang.ApplicationCore.Mappings;
using Elang.Domain.Entities;
using FluentValidation;

namespace Elang.ApplicationCore.Tests.Services;
public class CardServiceTests : IClassFixture<MapperBuilder<MapperProfile>>
{
    private static readonly Fixture _fixture = new Fixture();

    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IRepositoryBase<Card> _cardRepository;
    private readonly IValidator<CreateCardDto> _createCardValidator;
    private readonly IValidator<CardDto> _cardValidator;
    private readonly IValidator<CardFilterDto> _cardFilterValidator;

    //private readonly UpdateCardService _sut;
    public CardServiceTests(MapperBuilder<MapperProfile> mapperBuilder)
    {
        //_topicRepository = Mock.Of<IRepositoryBase<Topic>>();
        //_cardRepository = Mock.Of<IRepositoryBase<Card>>();
        //_createCardValidator = Mock.Of<IValidator<CreateCardDto>>();
        //_cardValidator = Mock.Of<IValidator<CardDto>>();
        //_cardFilterValidator = Mock.Of<IValidator<CardFilterDto>>();

        //IMapper mapper = mapperBuilder.Mapper;

        //_sut = new(_topicRepository, _cardRepository, mapper, _cardValidator);
    }

    //[Fact]
    //public async Task GetCard_Success_WhenCardExists()
    //{
    //    // ARRANGE
    //    var testCard = _fixture.Build<Card>()
    //                           .With(x => x.Topics, new List<Topic>()
    //                           {
    //                               new Topic { Id = 1 },
    //                               new Topic { Id = 2 }
    //                           })
    //                           .Without(x => x.Topics)
    //                           .Create();

    //    Mock.Get(_cardRepository).Setup(x => x.GetByIdAsync<long>(testCard.Id, default)).ReturnsAsync(testCard);
    //    // ACT
    //    var result = await _sut.GetCard(testCard.Id, default);
    //    // ASSERT
    //    result.Status.Should().Be(ResponseStatus.Success);
    //    result.Value.Should().BeEquivalentTo(new CardDto
    //    {
    //        Id = testCard.Id,
    //        ContextDescription = testCard.ContextDescription,
    //        English = testCard.English,
    //        Translation = testCard.Translation,
    //        Topics = new long[] { 1, 2 },
    //        Type = testCard.Type.ToString(),
    //    });
    //}

    //[Fact]
    //public async Task AddCard_Success_WhenCreateDataValid()
    //{
    //    // ARRANGE
    //    var testCardDto = _fixture.Build<CreateCardDto>()
    //                              .With(x => x.Type, CardType.Word.ToString())
    //                              .With(x => x.Topics, new long[] { 1, 2 })
    //                              .Create();
    //    var testTopics = new List<Topic>()
    //        {
    //            new(){ Id = 1, Name = "name1" },
    //            new(){ Id = 2, Name = "name2" }
    //        };
    //    Mock.Get(_cardRepository)
    //        .Setup(x => x.AddAsync(It.IsAny<Card>(), default))
    //        .ReturnsAsync(new Card
    //        {
    //            Id = 1
    //        });
    //    Mock.Get(_topicRepository)
    //        .Setup(x => x.ListAsync(It.IsAny<TopicByIdsSpecification>(), default))
    //        .ReturnsAsync(testTopics);
    //    Mock.Get(_createCardValidator)
    //        .Setup(x => x.ValidateAsync(testCardDto, default))
    //        .ReturnsAsync(new ValidationResult());
    //    // ACT
    //    var result = await _sut.AddCard(testCardDto, default);
    //    // ASSERT
    //    result.Status.Should().Be(ResponseStatus.Success);
    //    result.Value.Should().Be(1);
    //    var expectedCard = new Card
    //    {
    //        ContextDescription = testCardDto.ContextDescription,
    //        English = testCardDto.English,
    //        Translation = testCardDto.Translation,
    //        Type = CardType.Word,
    //        Topics = testTopics
    //    };

    //    Mock.Get(_cardRepository).Verify(x => x.AddAsync(It.Is<Card>(x => x == expectedCard), default), Times.Once);
    //}

    //[Fact]
    //public async Task UpdateCard_Success_WhenUpdateDataValidAndCardExists()
    //{
    //    // ARRANGE
    //    var testCardDto = _fixture.Build<CardDto>()
    //                             .With(x => x.Type, CardType.Word.ToString())
    //                             .With(x => x.Topics, new long[] { 1, 2 })
    //                             .Create();
    //    var testTopics = new List<Topic>()
    //        {
    //            new(){ Id = 1, Name = "name1" },
    //            new(){ Id = 2, Name = "name2" }
    //        };
    //    var testCard = _fixture.Build<Card>().With(x => x.Topics, testTopics).Create();
    //    var expectedCard = new Card
    //    {
    //        ContextDescription = testCardDto.ContextDescription,
    //        English = testCardDto.English,
    //        Id = testCardDto.Id,
    //        Topics = testTopics,
    //        Translation = testCardDto.Translation,
    //        Type = CardType.Word
    //    };
    //    Mock.Get(_cardValidator)
    //        .Setup(x => x.ValidateAsync(testCardDto, default))
    //        .ReturnsAsync(new ValidationResult());
    //    Mock.Get(_cardRepository)
    //        .Setup(x => x.GetByIdAsync<long>(testCardDto.Id, default))
    //        .ReturnsAsync(testCard);
    //    Mock.Get(_cardRepository)
    //        .Setup(x => x.UpdateAsync(It.Is<Card>(x => x == expectedCard), default));
    //    // ACT
    //    var result = await _sut.UpdateCard(testCardDto, default);
    //    // ASSERT
    //    result.Status.Should().Be(ResponseStatus.Success);
    //    Mock.Get(_cardRepository)
    //        .Verify(x => x.UpdateAsync(It.IsAny<Card>(), default), Times.Once);
    //}

    //[Fact]
    //public async Task DeleteCard_Success_WhenCardExists()
    //{
    //    // ARRANGE
    //    var testCard = _fixture.Build<Card>().Without(x => x.Topics).Create();
    //    Mock.Get(_cardRepository)
    //        .Setup(x => x.GetByIdAsync<long>(testCard.Id, default))
    //        .ReturnsAsync(testCard);
    //    Mock.Get(_cardRepository)
    //        .Setup(x => x.DeleteAsync(It.Is<Card>(x => x == testCard), default));
    //    // ACT
    //    var result = await _sut.DeleteCard(testCard.Id, default);
    //    // ASSERT
    //    result.Status.Should().Be(ResponseStatus.Success);
    //    Mock.Get(_cardRepository)
    //        .Verify(x => x.DeleteAsync(It.IsAny<Card>(), default), Times.Once);
    //}

}
