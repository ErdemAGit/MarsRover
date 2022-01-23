using Microsoft.Extensions.DependencyInjection;
using MarsRover.Core;
using MarsRover.Core.Commands;

namespace MarsRover
{
    public class Startup
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateauGrid, PlateauGrid>();
            services.AddTransient<ICommand, MoveCommand>();
            services.AddTransient<IPlateauCommand, PlateauCommand>();
            services.AddTransient<IDeployRoverCommand, DeployRoverCommand>();
            services.AddTransient<IPosition, Position>();
            services.AddTransient<IMoveCommand, MoveCommand>();
            services.AddTransient<IRoverAction, RoverAction>();
            services.AddTransient<IMarsRoverController, MarsRoverController>();

            return services.BuildServiceProvider();
        }
    }
}
