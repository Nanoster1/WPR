using WPR.Core.Domains.Links.Models;
using WPR.Core.Domains.Projects.Models;

namespace WPR.Web.Dto.Projects;

public record ProjectCreatingDto
(
    Project Project,
    Link[]? Links
);