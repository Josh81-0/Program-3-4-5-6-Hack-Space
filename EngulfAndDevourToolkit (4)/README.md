### Assignment 4 Refactoring Notes

**Components Created & Responsibilities**

- `FutureValueInputs.razor`: Collects principal, rate, years → triggers calculation via EventCallback
- `FutureValueResults.razor`: Displays computed/saved future value results
- `BalanceSheetList.razor`: Renders table of assets or liabilities with edit/delete buttons
- `BalanceSheetItemDialog.razor`: Modal form for adding/editing one line item
- `ReserveStudyFilters.razor`: Inputs for number of units + calculate trigger
- `ReserveItemList.razor`: Displays reserve components table with edit/delete
- `ReserveItemDialog.razor`: Form dialog for add/edit reserve component
- `MonthlyTotalsChart.razor`: Renders bar chart of 30-year expenditures

**Where State Lives and Why**

State lives in each page component (FutureValue.razor, BalanceSheet.razor, ReserveStudy.razor).  
Reason: Pages are the feature owners → they coordinate child components, hold lists/results, call services, and persist data. Children are presentational or form-focused and receive data/callbacks only.

**EventCallback Flow**

- Child (dialog/list row) → Parent: `EventCallback` for Save/Update/Delete actions (e.g., `OnSave`, `OnEdit`, `OnDelete`)
- Parent updates own list/state → calls persistence service → re-renders children
- Unidirectional flow: data down via [Parameter], events up via EventCallback

**AI Usage Disclosure**

Grok (xAI) was used minimally to recall Blazor dialog patterns and JSON persistence approaches. All code was manually adapted, tested, and written to match the existing project structure and assignment rules.