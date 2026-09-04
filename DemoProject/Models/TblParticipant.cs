using System;
using System.Collections.Generic;

namespace DemoProject.Models;

public partial class TblParticipant
{
    public int ParticipantId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
