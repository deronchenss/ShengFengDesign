using System.Data.SqlClient;
using ShengFengDesign.Models;
using ShengFengDesign.Repository.Interface;
using System.Text;
using System.Text.Json;
using Dapper;
using ShengFengDesign.Context;
using ShengFengDesign.Models.Album;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace ShengFengDesign.Repository
{
    public class Repository : IRepository
    {
        private readonly DapperContext _context;

        public Repository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveContactUs(ContactUs contactus)
        {
            _context.sql = @"INSERT INTO [dbo].[Contacts] ([Username]
                                        ,[Email]
                                        ,[UserRole]
                                        ,[Message]
                                        ,[MessengerType]
                                        ,[MessengerId]) 
                            VALUES (@Username,@Email,@UserRole,@Message,@MessengerType,@MessengerId)";
            return await _context.ExecuteSql(contactus) > 0;
        }

        public async Task<List<AlbumModel>> GetAlbumList(string culture = "")
        {
            _context.sql = @"SELECT [ID]
                                ,[Title]
                                ,[Content]
                              FROM [ShengFengDB].[dbo].[Album] WITH(NOLOCK)
                              WHERE LANGUAGE LIKE '%' + @LANGUAGE + '%'
                              ORDER BY ModifyTime DESC";
            _context.parameter.Add("LANGUAGE", culture);
            return await _context.GetQueryListData<AlbumModel>();
        }

        public async Task<AlbumModel> GetAlbum(string id, string culture = "")
        {
            _context.sql = @"SELECT [ID],[Title]
                                ,[Content]
                                ,Author  as [Author]
                                ,AU.[JobTitle]  as [AuthorJobTitle]
                                ,AU.[Description] as [AuthorDescription]
                                ,[ModifyTime]
                                ,AU.[Author_ID]
                            FROM [ShengFengDB].[dbo].[Album] as KB
                            LEFT JOIN [AuthorList] AU ON KB.[Author_ID] = AU.[Author_ID]
                            WHERE [ID] = @ID
                            AND LANGUAGE LIKE '%' + @LANGUAGE + '%'
                            ORDER BY KB.ModifyTime DESC";

            _context.parameter.Add("ID", id);
            _context.parameter.Add("LANGUAGE", culture);
            return await _context.GetQueryData<AlbumModel>();
        }
    }
}
