#pragma once
#include <SDL2/SDL.h>
#include <iostream>
#include "../Constantes.hpp"

class Timer
{
    private:
	    Timer();
    //The clock time when the timer started
    int startTicks;

    //The ticks stored when the timer was paused
    int pausedTicks;
    
	int _contando;

    //The timer status
    bool paused;
    bool started;
    public:
    //Initializes variables
    static Timer& getInstance();
    ~Timer();
    
    //The various clock actions
    void start();
    void stop();
    void pause();
    void unpause();
	bool wait(int tiempo);
    //Gets the timer's time
    int get_ticks();

	//Obtener el tiempo del timer desde la ultima llamada
	int getUpdateTicks();
	int lastUpdateTicks;
    
    //Checks the status of the timer
    bool is_started();
    bool is_paused(); 
};
