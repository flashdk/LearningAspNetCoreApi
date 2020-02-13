using ComedyEvents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyEvents.Infrastructure.EntityConfigurations
{
    class ComedianConfiguration
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comedian> builder)
        {
            builder.HasKey(_ => _.Id);
        }
    }
}
