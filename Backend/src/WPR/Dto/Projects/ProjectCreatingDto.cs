using WPR.Core.Domains.Links.Models;
using WPR.Core.Domains.Projects.Models;

namespace WPR.Dto.Projects;

public record ProjectCreatingDto
(
    Project Project,
    IEnumerable<Link> Links
);