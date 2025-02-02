﻿namespace Domain.Interfaces;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }

    DateTime? DeletedAt { get; set; }

    void SoftDelete();
}
