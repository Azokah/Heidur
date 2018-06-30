#include "Timer.hpp"


Timer& Timer::getInstance(){
	static Timer instance;
	return instance;
}
Timer::~Timer(){};
Timer::Timer()
{
    //Initialize the variables
    startTicks = 0;
    pausedTicks = 0;
    paused = false;
    started = false;
	_contando = -1;
	lastUpdateTicks = 0;
	start();
}
void Timer::start()
{
    //Start the timer
    started = true;
    
    //Unpause the timer
    paused = false;
    _contando = -1;
    //Get the current clock time
    startTicks = SDL_GetTicks();    
}
void Timer::stop()
{
    //Stop the timer
    started = false;
    
    //Unpause the timer
    paused = false;    
}
int Timer::getUpdateTicks()
{
	int t;
	if (lastUpdateTicks == 0)
	{
		lastUpdateTicks = SDL_GetTicks() - startTicks;
		t = 1;
	}
	else
	{
		t = (SDL_GetTicks() - startTicks) - lastUpdateTicks;
	}
    //If the timer is running
    if( started == true )
    {
        //If the timer is paused
        if( paused == true )
        {
            //Return the number of ticks when the timer was paused
            return pausedTicks;
        }
        else
        {
            //Return the current time minus the start time
			return t;

        }    
    }
    
    //If the timer isn't running
    return 0;    
}

int Timer::get_ticks()
{
	//If the timer is running
	if (started == true)
	{
		//If the timer is paused
		if (paused == true)
		{
			//Return the number of ticks when the timer was paused
			return pausedTicks;
		}
		else
		{
			//Return the current time minus the start time
			return SDL_GetTicks() - startTicks;
		}
	}

	//If the timer isn't running
	return 0;
}
void Timer::pause()
{
    //If the timer is running and isn't already paused
    if( ( started == true ) && ( paused == false ) )
    {
        //Pause the timer
        paused = true;
    
        //Calculate the paused ticks
        pausedTicks = SDL_GetTicks() - startTicks;
    }
}
void Timer::unpause()
{
    //If the timer is paused
    if( paused == true )
    {
        //Unpause the timer
        paused = false;
    
        //Reset the starting ticks
        startTicks = SDL_GetTicks() - pausedTicks;
        
        //Reset the paused ticks
        pausedTicks = 0;
    }
}
bool Timer::is_started()
{
    return started;    
}

bool Timer::is_paused()
{
    return paused;    
}

bool Timer::wait(int tiempo)
{
	if(_contando == -1)
	{
		_contando = get_ticks();
	}
	if(get_ticks() > _contando+tiempo)
	{
		_contando = -1;
		return true;
	}
	else
	{
		return false;
	}
};
