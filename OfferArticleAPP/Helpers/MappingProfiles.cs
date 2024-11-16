using AutoMapper;
using Infrastructure.Models;
using OfferArticleWebApi.Dto;
using RetailProcurementApp.Dto;

namespace OfferArticleWebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Article, ArticleCreateDto>();
            CreateMap<Article, ArticleIdDto>();
            CreateMap<ArticleCreateDto, Article>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Offers, opt => opt.Ignore());
            CreateMap<Offer, OfferDto>();
            CreateMap<Offer, OfferIdDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleOfferItem, ArticleOfferItemDto>()
                .ForMember(x => x.ArticleName, m => m.MapFrom(u => u.Article.ArticleName));

            CreateMap<Offer, OfferIdDto>();

            CreateMap<OfferDto, Offer>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Articles, opt => opt.Ignore())
                .ForMember(x => x.Date, opt => opt.Ignore());

            CreateMap<UpdateOrCreateArticleOfferItemDto, ArticleOfferItem>()
                .ForMember(x => x.OfferId, opt => opt.Ignore())
                .ForMember(x => x.Offer, opt => opt.Ignore())
                .ForMember(x => x.Article, opt => opt.Ignore());
        }
    }
}
