using Microsoft.AspNetCore.Mvc;
using ProductCatalogMicroService.Application;

namespace ProductCatalogMicroService.Presentation;

[ApiController]
[Route("[controller]")]
public class CompanyController(ICompanyService companyService) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;

    [HttpPost]
    public async Task<ActionResult<CompanyDto>> CreateCompanyAsync(CompanyDto info)
    {
        return Ok(await _companyService.CreateCompanyAsync(info));
    }

    [HttpGet]
    public async Task<ActionResult<List<CompanyDto>>> GetAllCompanies()
    {
        return Ok(await _companyService.GetAllCompaniesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDto>?> GetCompanyDto(int id)
    {
        return Ok(await _companyService.GetCompanyDtoAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CompanyDto>?> UpdateCompanyAsync(int id, CompanyDto info)
    {
        return Ok(await _companyService.UpdateCompanyAsync(id, info));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CompanyDto>?> DeleteCompanyAsync(int id)
    {
        return Ok(await _companyService.DeleteCompanyAsync(id));
    }
}
