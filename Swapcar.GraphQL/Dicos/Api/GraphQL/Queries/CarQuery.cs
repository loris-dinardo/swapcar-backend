using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarQuery : ObjectGraphType
    {
        public CarQuery()
        {
            Field<StringGraphType>(
            name: "hello",
            resolve: context => "world"
            );

            Field<ListGraphType<CarBrandType>>("brands",
                resolve: context =>
                {
                    List<CarBrand> result = new List<CarBrand>();

                    result.Add(
                        new CarBrand()
                        {
                            Id = 1, Name = "VW", Models = new List<CarModel>()
                            {
                                new CarModel() { Id = 1, Name = "Polo", Versions = new List<CarVersion>()
                                    {
                                        new CarVersion() { Id = 1, Name = "Polo 1.4, 60Cv" },
                                        new CarVersion() { Id = 2, Name = "Polo 1.6, 90Cv" }
                                    }
                                },
                                new CarModel() { Id = 2, Name = "Golf", Versions = new List<CarVersion>()
                                    {
                                        new CarVersion() { Id = 3, Name = "Golf 1.6, 90Cv" },
                                        new CarVersion() { Id = 4, Name = "Golf 2.0, 120Cv" }
                                    }
                                }
                            }
                        }
                    );

                    result.Add(
                        new CarBrand()
                        {
                            Id = 2,
                            Name = "Fiat",
                            Models = new List<CarModel>()
                            {
                                new CarModel() { Id = 3, Name = "Panda", Versions = new List<CarVersion>()
                                    {
                                        new CarVersion() { Id = 5, Name = "Panda 1.4, 60Cv" },
                                        new CarVersion() { Id = 6, Name = "Panda 1.6, 90Cv" }
                                    }
                                },
                                new CarModel() { Id = 4, Name = "Uno", Versions = new List<CarVersion>()
                                    {
                                        new CarVersion() { Id = 7, Name = "Uno 1.0, 30Cv" },
                                        new CarVersion() { Id = 8, Name = "Uno 1.2, 45Cv" }
                                    }
                                }
                            }
                        }
                    );


                    return result;
                }
            );
        }
    }
}
