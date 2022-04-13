using WPR.Dto.Links;

namespace WPR.Dto.Projects;

public record ProjectDto
(
    Guid Id,
    string Name,
    int Rating,
    PrLinkDto[] StandardLinks,
    PrLinkDto[] Screenshots,
    PrLinkDto[] DownloadLinks,
    Guid AuthorId,
    string AuthorName,
    string ShortDesc,
    string LongDesc
);