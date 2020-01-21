# TimeMachine
A component written in C# that will provide an end date given a start date and length in minutes. Written as a .Net Core 3.1 console app. 

### The following business rules apply: 
We have a standard 40-hour work week; 8 am to 5 pm Monday through Friday. There is a one-hour break for lunch (12:00 to 1:00 pm). We have six holidays per year: New Year’s Day, Memorial Day, 4th of July, Labor Day, Thanksgiving and Christmas. 

For any given task, we assign the number of minutes it should take for the task to be completed. So, when a task is assigned, the start time is recorded, as well as the number of minutes assigned to complete the task.

Tasks can only be worked on during work hours. Tasks can be assigned at any time. The number of minutes will never exceed 1 year.
