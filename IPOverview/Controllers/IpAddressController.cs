using Microsoft.AspNetCore.Mvc;
using Models;
using System;


public class IpAddressController : Controller
{
    private readonly IpAddressManager ipAddressManager;

    public IpAddressController(IpAddressManager ipAddressManager)
    {
        this.ipAddressManager = ipAddressManager;
    }

    // Action to display a form for adding a new IP address entry
    public IActionResult Create()
    {
        return View();
    }

    // Action to handle the submission of the new IP address entry
    [HttpPost]
    public IActionResult Create(StaticIpAddress entry)
    {
        if (ModelState.IsValid)
        {
            if (!ipAddressManager.IpAddressExists(entry.IpAddress))
            {
                ipAddressManager.AddIpAddress(entry);
                return RedirectToAction("Index"); // Redirect to the list view
            }
            else
            {
                ModelState.AddModelError("IpAddress", "IP Address already exists.");
            }
        }

        return View(entry);
    }

    // Action to list all IP address entries    
    public IActionResult Index()
    {
        var entries = ipAddressManager.GetAllEntries();
        return View(entries);
    }


    // Edit an IP address entry - This functionality has been implemented!
    public IActionResult Edit(string ipAddress)
    {
        var entry = ipAddressManager.GetEntryByIpAddress(ipAddress);
        if (entry != null)
        {
            return View("Create", entry);
        }
        else
        {
            return NotFound();
        }
    }

    // Delete an IP address entry
    [HttpPost]
    public IActionResult Delete(string ipAddress)
    {
        if (ipAddressManager.RemoveIpAddress(ipAddress))
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
}