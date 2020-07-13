using BusinessRuleEngine.Entities.Departments;
using BusinessRuleEngine.Entities.Slips;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Validations;
using System;

namespace BusinessRuleEngine.Services
{
    public class PackagingSlipService : IPackagingSlipService
    {
        private readonly IPackagingSlipNumberGenerator packagingSlipNumberGenerator;

        public PackagingSlipService(IPackagingSlipNumberGenerator packagingSlipNumberGenerator)
        {
            this.packagingSlipNumberGenerator = packagingSlipNumberGenerator;
        }

        public PackagingSlipGenerationResponse GenerateNewSlip()
        {
            return new PackagingSlipGenerationResponse
            {
                PackagingSlipGenerationResponseType = PackagingSlipGenerationResponseType.Success,
                PackagingSlip = new PackagingSlip
                {
                    Id = Guid.NewGuid(),
                    Number = packagingSlipNumberGenerator.Generate()
                }
            };
        }

        public PackagingSlipGenerationResponse GenerateDuplicateSlip(Department department)
        {
            PackagingSlipGenerationResponse packagingSlipGenerationResponse;

            if (!department.Validate(out packagingSlipGenerationResponse))
            {
                return packagingSlipGenerationResponse;
            }

            return new PackagingSlipGenerationResponse
            {
                PackagingSlipGenerationResponseType = PackagingSlipGenerationResponseType.Success,
                PackagingSlip = new PackagingSlip
                {
                    Id = Guid.NewGuid(),
                    Number = packagingSlipNumberGenerator.Generate()
                }
            };
        }

        public PackagingSlipGenerationResponse GenerateSlipWithVideo()
        {
            return new PackagingSlipGenerationResponse
            {
                PackagingSlipGenerationResponseType = PackagingSlipGenerationResponseType.Success,
                PackagingSlip = new PackagingSlipVideo
                {
                    Id = Guid.NewGuid(),
                    Number = packagingSlipNumberGenerator.Generate(),
                    Video = new Entities.Videos.Video
                    {
                        Id = Guid.NewGuid(),
                        VideoType = Entities.Videos.VideoType.FirstAid
                    }
                }
            };
        }
    }
}
