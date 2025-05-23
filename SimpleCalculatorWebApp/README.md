# ASP.NET Web Calculator - IIS Deployment Guide

This guide will help you deploy the Web Calculator application to Internet Information Services (IIS).

## 📋 Prerequisites

### Server Requirements
- **Windows Server 2012 R2** or later (or Windows 10/11 Pro with IIS)
- **IIS 7.0** or later
- **.NET Framework 4.8** or later
- **ASP.NET Web Forms** feature enabled

### IIS Features Required
Ensure these IIS features are installed:
- ✅ **IIS Management Console**
- ✅ **ASP.NET 4.8** (or compatible version)
- ✅ **Static Content**
- ✅ **Default Document**
- ✅ **HTTP Compression** (recommended)

## 🚀 Deployment Steps

### Step 1: Download the Application
1. Download the latest **WebCalculator-[version].zip** from the [Releases](../../releases) page
2. Extract the ZIP file to a temporary location

### Step 2: Prepare IIS Directory
1. Create a new folder for the application:
   ```
   C:\inetpub\wwwroot\calculator
   ```
2. Copy all extracted files to this directory
3. Verify the folder structure:
   ```
   C:\inetpub\wwwroot\calculator\
   ├── bin/
   │   ├── WebCalculator.dll
   │   └── [other assemblies]
   ├── Content/
   │   └── Site.css
   ├── Default.aspx
   ├── Error.aspx
   ├── Global.asax
   ├── Web.config
   ├── favicon.ico
   └── DEPLOYMENT_INFO.txt
   ```

### Step 3: Configure IIS Application

#### Option A: Create New Website
1. Open **IIS Manager**
2. Right-click **Sites** → **Add Website**
3. Configure:
   - **Site name**: `Web Calculator`
   - **Physical path**: `C:\inetpub\wwwroot\calculator`
   - **Port**: `80` (or your preferred port)
   - **Host name**: `calculator.yourserver.com` (optional)

#### Option B: Create Virtual Directory
1. Open **IIS Manager**
2. Expand **Sites** → **Default Web Site**
3. Right-click **Default Web Site** → **Add Virtual Directory**
4. Configure:
   - **Alias**: `calculator`
   - **Physical path**: `C:\inetpub\wwwroot\calculator`

#### Option C: Create Application
1. Open **IIS Manager**
2. Expand **Sites** → **Default Web Site**
3. Right-click **Default Web Site** → **Add Application**
4. Configure:
   - **Alias**: `calculator`
   - **Physical path**: `C:\inetpub\wwwroot\calculator`
   - **Application Pool**: `DefaultAppPool` (or create new)

### Step 4: Configure Application Pool
1. In **IIS Manager**, click **Application Pools**
2. Select your application pool (usually **DefaultAppPool**)
3. Click **Basic Settings**
4. Ensure:
   - **.NET CLR Version**: `.NET CLR Version v4.0.30319`
   - **Managed Pipeline Mode**: `Integrated`
   - **Start Mode**: `OnDemand`

### Step 5: Set Permissions
1. Right-click the calculator folder in Windows Explorer
2. Select **Properties** → **Security** tab
3. Click **Edit** → **Add**
4. Add **IIS_IUSRS** with **Read & Execute** permissions
5. Add **IUSR** with **Read** permissions (if needed)

### Step 6: Test the Application
1. Open a web browser
2. Navigate to:
   - **New Website**: `http://yourserver:port/`
   - **Virtual Directory**: `http://yourserver/calculator/`
   - **Application**: `http://yourserver/calculator/`
3. You should see the calculator interface

## 🔧 Troubleshooting

### Common Issues

#### "HTTP Error 500.19 - Internal Server Error"
- **Cause**: Web.config configuration error
- **Solution**: Ensure .NET Framework 4.8 is installed and ASP.NET is registered

#### "HTTP Error 403.14 - Forbidden"
- **Cause**: Default document not configured
- **Solution**: Ensure `Default.aspx` is in the default documents list

#### "Could not load file or assembly"
- **Cause**: Missing dependencies or incorrect framework version
- **Solution**: Verify .NET Framework 4.8 is installed and bin folder is present

#### Calculator doesn't respond to clicks
- **Cause**: ViewState or session issues
- **Solution**: Check that session state is enabled in web.config

### Verification Commands
Run these PowerShell commands to verify your setup:

```powershell
# Check .NET Framework version
Get-ItemProperty "HKLM:SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\" -Name Release

# Check IIS features
Get-WindowsFeature | Where-Object {$_.Name -like "*IIS*" -and $_.InstallState -eq "Installed"}

# Test application pool
Import-Module WebAdministration
Get-WebApplication | Where-Object {$_.Path -eq "/calculator"}
```

## ⚙️ Configuration Options

### Performance Optimization
Edit `Web.config` to enable additional optimizations:

```xml
<system.webServer>
  <httpCompression>
    <dynamicTypes>
      <add mimeType="text/*" enabled="true" />
      <add mimeType="application/javascript" enabled="true" />
    </dynamicTypes>
  </httpCompression>
  <staticContent>
    <clientCache cacheControlMode="UseMaxAge" cacheControlMaxAge="7.00:00:00" />
  </staticContent>
</system.webServer>
```

### Security Hardening
Add security headers in `Web.config`:

```xml
<system.webServer>
  <httpProtocol>
    <customHeaders>
      <add name="X-Content-Type-Options" value="nosniff" />
      <add name="X-Frame-Options" value="DENY" />
      <add name="X-XSS-Protection" value="1; mode=block" />
    </customHeaders>
  </httpProtocol>
</system.webServer>
```

## 📊 Monitoring and Logs

### Application Logs
- **Location**: Windows Event Viewer → Windows Logs → Application
- **IIS Logs**: `C:\inetpub\logs\LogFiles\W3SVC1\`

### Performance Monitoring
- Monitor CPU and memory usage via Task Manager
- Use IIS Manager to view active connections and requests
- Enable detailed error logging in `Web.config` for troubleshooting

## 🔄 Updates and Maintenance

### Updating the Application
1. Stop the IIS application/site
2. Replace files with new version
3. Restart the application/site
4. Test functionality

### Backup Strategy
- Backup the entire application folder
- Export IIS configuration: `%windir%\system32\inetsrv\appcmd.exe list config`
- Document custom configuration changes

## 📞 Support

If you encounter issues:
1. Check the **DEPLOYMENT_INFO.txt** file for version information
2. Review IIS logs for error details
3. Verify all prerequisites are met
4. Create an issue in the [GitHub repository](../../issues) with:
   - Error messages
   - IIS configuration details
   - Windows/IIS version information

---

## 🎯 Quick Deployment Checklist

- [ ] Windows Server with IIS installed
- [ ] .NET Framework 4.8 installed
- [ ] ASP.NET features enabled in IIS
- [ ] Application files extracted to web directory
- [ ] IIS application/site created and configured
- [ ] Application pool set to .NET Framework v4.0
- [ ] Proper permissions set (IIS_IUSRS)
- [ ] Default.aspx accessible via browser
- [ ] Calculator functions working correctly

**🎉 Once all items are checked, your Web Calculator is ready for use!**