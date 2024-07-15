﻿namespace GerenciadorEstoque.Domain.Core;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public DateTime? DateDeleted { get; set; }
    public bool IsDeleted { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        DateCreated = DateTime.Now;
    }
}
