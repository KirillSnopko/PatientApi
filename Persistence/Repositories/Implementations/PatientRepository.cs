﻿using Domain.DbEntities;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Interfaces;


namespace Persistence.Repositories.Implementations;

public sealed class PatientRepository : AbstractCrudRepository<Patient, long>, IPatientRepository
{
    public PatientRepository(HospitalContext context) : base(context)
    {
    }
}
