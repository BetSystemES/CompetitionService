<h1>Competition Service</h1>
Provides competition related data. Data contains competition coefficient group which includes abstraction of outcome and their coefficients.
Provides deposit to coefficient functionality.
Provides competition ending functionality.

<h2>API Methods</h2>

<h3>CompetitionDota2 methods</h3>

| Method                   | Description                                                         |
| ------------------------ | ------------------------------------------------------------------- |
| CreateCompetitionDota2() | Create competition entity in database includes outcome groups.      |
| GetCompetitionsDota2()   | Get a list of CompetitionsDota2 by paging. List are sorted by time. |
| UpdateCompetitionDota2() | Update competitionDota2 with specific Id.                           |

<h3>General methods</h3>

| Method                             | Description                                                                                         |
| ---------------------------------- | --------------------------------------------------------------------------------------------------- |
| BlockCompetitionBaseById()         | Set status ended to competition and blocks coefficient groups with specific identifier.             |
| CalculateCompetitionBaseOutcomes() | Update outcomes statuses. Send outcomes statuses for Money Service                                  |
| DepositToCoefficientById()         | Deposit amount to coefficient entity with specific identifier. Returns rate of current coefficient. |

<h2>Entity examples</h2>

Example of competition_dota2 entity:

```
{
	"competition_dota2" : {
		"id" : "b350c9fd-3632-4b0a-b5cb-66e41d530f55",
		"type" : "COMPETITION_TYPE_ESPORTDOTA2",
		"status_type" : "COMPETITION_STATUS_TYPE_WAITING",
		"start_time" : 
		{
			"seconds": "60",
			 "nanos": 928852400
		},
		"coefficient_groups" : 
		[
			{
				"id" : "b350c9fd-3632-4b0a-b5cb-66e41d530f55",
				"name" : "winner",
				"type" : "OUTCOME_GROUP_TYPE_ONE_WINNER",
				"coefficients" : 
				[
						{
							"id" : "b350c9fd-3632-4b0a-b5cb-66e41d530f55",
							"description" : "team1 won",
							"rate" : 1.2,
							"status_type" : "COEFFICIENT_STATUS_TYPE_ACTIVE",
							"amount" : 0,
							"probability" : 50
						},
						{
							"id" : "3c203bd7-2d7e-4937-a82a-e451cedf2ba8",
							"description" : "team2 won",
							"rate" : 0,
							"status_type" : "COEFFICIENT_STATUS_TYPE_ACTIVE",
							"amount" : 0,
							"probability" : 50
						}
				]
			},
			{
				"id" : "1e52e2e0-af3e-4e8d-a8e1-a87a44114b59",
				"name" : "winner",
				"type" : "OUTCOME_GROUP_TYPE_ONE_WINNER",
				"coefficients" : 
				[
						{
							"id" : "b350c9fd-3632-4b0a-b5cb-66e41d530f55",
							"description" : "team1 won",
							"rate" : 1.2,
							"status_type" : "COEFFICIENT_STATUS_TYPE_ACTIVE",
							"amount" : 0,
							"probability" : 50
						},
						{
							"id" : "3c203bd7-2d7e-4937-a82a-e451cedf2ba8",
							"description" : "team2 won",
							"rate" : 0,
							"status_type" : "COEFFICIENT_STATUS_TYPE_ACTIVE",
							"amount" : 0,
							"probability" : 50
						}
				]
			}
		],
		"team1_id" : "b350c9fd-3632-4b0a-b5cb-66e41d530f55",
		"team2_id" : "b350c9fd-3632-4b0a-b5cb-66e41d530f55",
		"team1_kill_amount" : 0,
		"team2_kill_amount" : 0,
		"total_time" : 
		{
			"seconds": "60",
			 "nanos": 928852400
		}
	}
}
```