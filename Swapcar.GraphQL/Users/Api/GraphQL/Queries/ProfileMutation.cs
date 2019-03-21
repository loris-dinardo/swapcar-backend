using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;
using Swapcar.GraphQL.Users.Api.GraphQL.Types;
using Swapcar.GraphQL.Users.Domain.Models;
using Swapcar.GraphQL.Users.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Users.Api.GraphQL.Queries
{
    public class ProfileMutation : ObjectGraphType, ICoreGraphMutationIncluder
    {
        public ProfileMutation(ProfileRepository profileRepository)
        {
            /**
             * NEW PROFILE
             */
            Field<ProfileType, Profile>()
                .Name("createProfile")
                .Argument<NonNullGraphType<ProfileInputType>>("profile", "profile input")
                .ResolveAsync(async ctx =>
                {
                    var profile = ctx.GetArgument<Profile>("profile");
                    return await profileRepository.Add(profile);
                });

            /**
             * UPDATE PROFILE
             */
            Field<ProfileType, Profile>()
                .Name("updateProfile")
                .Argument<NonNullGraphType<ProfileInputType>>("profile", "profile input")
                .ResolveAsync(async ctx =>
                {
                    var profile = ctx.GetArgument<Profile>("profile");

                    // Check if profile exists
                    var currentProfile = await profileRepository.FindById(profile.Id);
                    if (currentProfile == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Profile not found"));
                        return null;
                    }
                    // Update profile
                    return await profileRepository.Update(profile);
                });

            /**
             * DELETE PROFILE
             */
            Field<ProfileType, Profile>()
                .Name("deleteProfile")
                .Argument<NonNullGraphType<IdGraphType>>("id", "profile id input")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");

                    // Check if profile exists
                    var currentProfile = await profileRepository.FindById(id);
                    if (currentProfile == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Profile not found"));
                        return null;
                    }
                    // delete profile
                    await profileRepository.Remove(id);

                    return null;
                });
        }
    }
}
