using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseEnum : MonoBehaviour
{ }

public enum planetyCommon // you can see them without telescope and its not a problem 
{ 
    Mercury, //merkury
    Venus, //wenus
    Mars, //mars 
    Jupiter, // jowisz
    Saturn, // saturn
    Polaris //northern star, we can call it either polaris or northern star or both at once idk honestly ~Luuq
}

public enum planetyUncommon // you can either spot them without telescope but they're rare to spot this way or u can see them easily with telescope
{
    Arcturus, // red giant, one of the brightest starts that you are able to see in night without a telescope ------------ u can see them without telescope but they're rare 
    Antares, // red supergiant // the brightest star in constelation of scorpius ------------ u can see them without telescope but they're rare 
    Uranus, // uran // its slow but with rapis spin, you can easily confuse it with background stars 
    Neptune, // neptun // u can easily spot it with binoculars or a telescope
    Triton // largest moon of neptune, it shines at magnitude 13.5 where naptune shines at 7.7. Kreci sie w druga strone niz neptun 
}

public enum planetyRare // u need observatory or idk what else, hard to find planets ;c
{
    ProximaCentauriB, // exoplanet orbiting in the habitable zone of the red dwarf Proxima Centauri, which is closest star to the sun apart of the triple star system alpha centauri.
    Kepler452b, //only planet discovered by Kepler. Its super-earth exoplanet orbiting within the inner edge of the habitable zone of star Kepler-452
    Wasp17b, // exoplanet in the constellation Scorpius that is orbiting the star Wasp-17.It is the first planet discovered to have a retrograde orbit, meaning it orbits in a direction counter to the rotation of its host star
    Brahe, // 55 cancri c // exoplanet in an eccentric orbit around the sun-like star 55 Cancri A. It has mass of almost 1/6 of jupiter or roughly 1/2 of saturn
    Ran // EpsilonEridani (its sun :DD) //

}