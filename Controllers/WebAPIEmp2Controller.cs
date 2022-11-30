using Microsoft.AspNetCore.Mvc;
using WebAPIEmp2.Models;

namespace WebAPIEmp2.Controllers;

[ApiController]
[Route("[controller]")]
public class WebAPIEmp2: ControllerBase
{
    
    private readonly EmployeeContext _DbContext;

    public WebAPIEmp2(EmployeeContext dbContext)
    {
        this._DbContext=dbContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var emp=this._DbContext.EmpPersonalInfos.ToList();
        return Ok(emp);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody]EmpPersonalInfo _empPersonalInfo)
    {
        var emp=this._DbContext.EmpPersonalInfos.FirstOrDefault(o=>o.EmpId==_empPersonalInfo.EmpId);
        if(emp!=null){
                           emp.Fname=_empPersonalInfo.Fname;
                           emp.Lname=_empPersonalInfo.Lname;
                           emp.MobNumber=_empPersonalInfo.MobNumber;
                           
                            this._DbContext.SaveChanges();
        
                    }
        else{
                
            this._DbContext.SaveChanges();
        }
      return Ok(true);
       
    }

    [HttpGet("GetById/{EmpId}")]
    public IActionResult GetById(int id)
    {
       var emp=this._DbContext.EmpPersonalInfos.FirstOrDefault(o=>o.EmpId==id);
       return Ok(emp);
    }

    [HttpDelete("DelById/{EmpId}")]
    public IActionResult DelById(int id)
    {
       var emp=this._DbContext.EmpPersonalInfos.FirstOrDefault(o=>o.EmpId==id);
       if(emp!=null){
        this._DbContext.Remove(emp);
        this._DbContext.SaveChanges();
        return Ok(true);
       }
       return Ok(false);
    }

}    