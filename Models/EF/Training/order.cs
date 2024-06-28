﻿using System;
using System.Collections.Generic;

namespace timefree_training_api.Models.EF.Training
{
    public partial class order
    {
        public Guid guid { get; set; }
        public Guid user_guid { get; set; }
        public Guid product_guid { get; set; }
        public int? quantity { get; set; }
        public bool? _deleted { get; set; }
        public DateTime date_created { get; set; }
        public Guid? created_by { get; set; }
        public string? created_by_ip { get; set; }
        public Guid? modified_by { get; set; }
        public string? modified_by_ip { get; set; }
        public DateTime? date_modified { get; set; }

        public virtual product product_gu { get; set; } = null!;
        public virtual user user_gu { get; set; } = null!;
    }
}
