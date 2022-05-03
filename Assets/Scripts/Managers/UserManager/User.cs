using System;
using System.Linq;

[Serializable]
public class User
{
    private const int START_TIME_VALUE = 20;
    private const int START_HEALTH_VALUE = 5;
    private const int START_COINS_VALUE = 0;

    private int _timer;
    private int _health;
    private int _coins;
    
    public User()
    {
        _timer = START_TIME_VALUE;
        _health = START_HEALTH_VALUE;
        _coins = START_COINS_VALUE;
    }

    public int Timer
    {
        get
        {
            if (_timer < 0) return 0;
            if (_timer > START_TIME_VALUE) return START_TIME_VALUE;
            return _timer;
        }
        set
        {
            if (value < 0)
            {
                _timer = 0;
                return;
            }
            
            if (value > START_TIME_VALUE)
            {
                _timer = START_TIME_VALUE;
                return;
            }
            
            _timer = value;
        }
    }
    
    public int Health
    {
        get
        {
            if (_health < 0) return 0;
            if (_health > 5) return START_HEALTH_VALUE;
            return _health;
        }
       
        
        set
        {
            if (value < 0)
            {
                _health = 0;
                return;
            }
            
            if (value > START_HEALTH_VALUE)
            {
                _health = START_HEALTH_VALUE;
                return;
            }
            
            _health = value;
        }
    }
    
    public int Coins
    {
        get
        {
            if (_coins < 0) return 0;
            return _coins;
        }
        
        set
        {
            if (value < 0)
            {
                _coins = 0;
                return;
            }
            _coins = value;
        }
    }
    
}