﻿using System;
using System.Collections.Generic;

namespace timefree_training_api.Models.EF.Training
{
    public partial class user
    {
        public user()
        {
            order = new HashSet<order>();
        }

        public Guid guid { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public bool _deleted { get; set; }
        /// <summary>
        /// always in UTC time
        /// </summary>
        public DateTime date_created { get; set; }
        public Guid? created_by { get; set; }
        public string? created_by_ip { get; set; }
        public DateTime? date_modified { get; set; }
        public Guid? modified_by { get; set; }
        public string? modified_by_ip { get; set; }

        public virtual ICollection<order> order { get; set; }
    }
}
