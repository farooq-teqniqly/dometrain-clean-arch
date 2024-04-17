# dometrain-clean-arch

## EF Core Commands

Add migration
```powershell
dotnet ef migrations add InitialSubscriptions -c SubscriptionsDbContext -p .\GymManagement.Subscriptions\GymManagement.Subscriptions.csproj -s .\GymManagement.Api\GymManagement.Api.csproj -o .\Data\Migrations
```
Update database
```powershell
dotnet ef database update -c SubscriptionsDbContext -p .\GymManagement.Subscriptions\GymManagement.Subscriptions.csproj -s .\GymManagement.Api\GymManagement.Api.csproj
```