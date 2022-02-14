using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using GrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{

    public class AppMapper
    {

        public static IMapper Mapper;
        static AppMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });
            Mapper = config.CreateMapper();
        }
    }


    public class HelloGrain: Grain,IHelloGrain
    {


        public async Task<string> Test(UserDTO dto)
        {
            var obj = AppMapper.Mapper.Map<UserDTO, User>(dto);
            return $"suc for call";
        }

        public async Task<List<UserDTO>> List(Expression<Func<UserDTO,bool>> expr)
        {

            try
            {

                //will throw FatalExecutionEngineError
                var expr2 = AppMapper.Mapper.MapExpression<Expression<Func<UserDTO, bool>>, Expression<Func<User, bool>>>(expr);


                return new List<UserDTO>();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
