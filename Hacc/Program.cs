using BussinessLayer.Abstract.BlogAbstract;
using BussinessLayer.Concrete.BlogConcrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.EntityFramework.BlogEntityFramework;
using EntityLayer.Entities;
using Hacc.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Hacc_Database")));
builder.Services
    .AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();


builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
builder.Services.AddScoped<ICategoryDal, EFCategoryRepository>();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region Contact
//EFContactRepository efContact = new EFContactRepository();
//IContactService service = new ContactManager(efContact);

//Contact contact = new Contact()
//{
//    Name = "Hacc Contact Info",
//    Address = new Address()
//    {
//        AddressUrl = "https://goo.gl/maps/gBYGZvHMGBj5sKm28",
//        Name = "7 Mirza Fatali Akhundov, Baku 1001, Azerbaycan",
//    },
//    Status = 1,
//    HasImg = 0,
//    ImageText = null,
//    PhoneNumbers = new List<Phone>()
//    {
//        //012-437-15-71 -- 070-214-54-24
//        new Phone()
//        {
//            PhoneNumber = "+994 12 492 00 57",
//        },
//        new Phone()
//        {
//            PhoneNumber = "+994 12 437 15 71",
//        },
//        new Phone()
//        {
//            PhoneNumber = "+994 70 214 54 24"
//        },
//    },
//    SocialMediaAccounts = new List<SocialMedia>()
//    {
//        new SocialMedia()
//        {
//            Data= "https://www.twitter.com",
//            PlatformName="Twitter",
//        },
//        new SocialMedia()
//        {
//            Data = "https://www.instagram.com/qafqazmuselmanlar.ziyaret",
//            PlatformName="Instagram",
//        },
//        new SocialMedia()
//        {
//            PlatformName="Facebook",
//            Data = "https://www.facebook.com"
//        },
//    },
//    Email = "qafqazmuselmanlar@gmail.com",
//    Description = "null",
//};

//SocialMedia wp = new SocialMedia();
//wp.Data = "https://wa.me/+994702145424";
//wp.PlatformName = "WhatsApp";

//contact.SocialMediaAccounts.Add(wp);
////service.ContactUpdate(contact);

#endregion
#region data
EFBlogRepository blogRepo = new EFBlogRepository();
IBlogService blogService = new BlogManager(blogRepo);

EFPostRepository postRepo = new EFPostRepository();
IPostService postService = new PostManager(postRepo);

EFTagRepository tagRepo = new EFTagRepository();
ITagService tagService = new TagManager(tagRepo);

//Creating data

//Post post = new Post();
//post.Title = "Asp .Net Mvc New Video Published!";
//post.Body = "Micrsoft Published New ASP .NET version with developers.Developers are very excited because they don't know how to change their .NET 6 projects to .NET 7";
//post.CreateDate = DateTime.UtcNow;
//post.Images = new List<Image> {
//    new Image {
//        Url= "https://www.educative.io/cdn-cgi/image/f=auto,fit=contain,w=600/api/page/6272284694675456/image/download/5249964031082496",
//        BackupUrl="https://www.educative.io/cdn-cgi/image/f=auto,fit=contain,w=600/v2api/collection/10370001/5168843929944064/image/5237286403047424",
//        Status=1,
//},
//    new Image
//    {
//        Url="https://www.galaxy-education.com/wp-content/uploads/2022/11/ASP.Net-Programming-Courses-in-Abu-Dhabi.png",
//        BackupUrl="https://www.educative.io/cdn-cgi/image/f=auto,fit=contain,w=600/v2api/collection/10370001/5168843929944064/image/5237286403047424",
//        Status=1,
//    },
//    new Image
//    {Url = "https://www.educative.io/cdn-cgi/image/f=auto,fit=contain,w=600/v2api/collection/10370001/5168843929944064/image/5237286403047424",
//        BackupUrl = "https://www.educative.io/cdn-cgi/image/f=auto,fit=contain,w=600/v2api/collection/10370001/5168843929944064/image/5237286403047424",
//        Status = 1
//    }
//};
//Image image = new Image
//{
//    Url = "https://img.stackshare.io/service/11331/asp.net-core.png"
//};
//post.Thumbnail = image.Url;
//List<Tag> tags = new List<Tag>
//{
//    new Tag
//    {
//        Name = "Developing",
//        Status = 1,
//        CreateDate = DateTime.UtcNow,
//    },
//    new Tag
//    {
//        Name = "C#",
//        Status = 1,
//        CreateDate = DateTime.UtcNow,
//    },
//    new Tag
//    {
//        Name = "ASP .NET",
//        Status = 1,
//        CreateDate = DateTime.UtcNow,
//    },
//    new Tag
//    {
//        Name = "Web Developing",
//        Status = 1,
//        CreateDate = DateTime.UtcNow,
//    },
//};
//post.Tags = tags;
//post.Status = 1;

//EFImageRepository ImageRepo = new EFImageRepository();
//IImageService imageService = new ImageManager(ImageRepo);

//imageService.ImageAdd(image);
//foreach (var img in post.Images)
//{
//    imageService.ImageAdd(img);
//}
//foreach (var tag in tags)
//{
//    tagService.TagAdd(tag);
//}

//postService.PostAdd(post);

//Blog blog = new Blog();
//blog.Name = "News";
//blog.CreateTime = DateTime.UtcNow;
//blog.Status = 1;



//blog.Posts.Add(post);
//blogService.BlogAdd(blog);
#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists=admin}/{controller=admin}/{action=RolesList}/{id?}");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists=admin}/{controller=admin}/{action=UsersList}/{id?}"
    );
});

app.MapRazorPages();
app.Run();
