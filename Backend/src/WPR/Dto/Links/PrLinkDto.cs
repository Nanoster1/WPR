namespace WPR.Dto.Links;

public record PrLinkDto
(
    //Нужно ли?
    Guid Id,
    string Title,
    Uri Url
);