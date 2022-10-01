using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseEnum : MonoBehaviour
{ }

public enum planetyCommon // you can see them without telescope and its not a problem 
{
    Mercury, //merkury // is the smallest planet in the solar system and the closest to the Sun.
    Venus, //wenus // is second planet from the Sun. As the brightest natural object in Earth's sky after the Moon, Venus can cast shadows and can be visible to the naked eye in broad daylight. 
    Mars, //mars // is the fourth planet from the sun and the second-smallest planet in our solar system. Mars is cerrestial planet with a thin atmosphere, it has a core made out of iron and nickel.
    Jupiter, // jowisz // is the fifth planet from the Sun and the largest in our solar system. It's a gas giant it has 2.5x mass of all other planets in our solar system combined.
    Saturn, // saturn //  is the sixth planet from the Sun and the second-largest in the Solar System, after Jupiter. It is a gas giant with an average radius of about nine and a half times that of Earth.It has only one-eighth the average density of Earth.
    Polaris // is a star in the northern circumpolar constellation of Ursa Minor. It is designated Alpha Ursae Minoris and is commonly called the North Star or Pole Star.
}
public enum planetyUncommon // you can either spot them without telescope but they're rare to spot this way or u can see them easily with telescope
{
    Arcturus, //  is the brightest star in the northern constellation of Boötes. It is the third-brightest of the individual stars in the night sky, and the brightest in the northern celestial hemisphere.
    Antares, //  is a red supergiant, a large evolved massive star and one of the largest stars visible to the naked eye. Its exact size remains uncertain, but if placed at the center of the Solar System, it would reach to somewhere between the orbits of Mars and Jupiter.
    Uranus, // uran // is the seventh planet from the Sun. It has the third-largest planetary radius and fourth-largest planetary mass in the Solar System. Uranus is similar in composition to Neptune.
    Neptune, // neptun //  is the eighth planet from the Sun and the farthest known solar planet. In the Solar System, it is the fourth-largest planet by diameter, the third-most-massive planet, and the densest giant planet. It is 17 times the mass of Earth, and slightly more massive than its near-twin Uranus.
    Triton //  is the largest natural satellite of the planet Neptune, and was the first Neptunian moon to be discovered. It is the only large moon in the Solar System with a retrograde orbit, an orbit in the direction opposite to its planet's rotation.
}

public enum planetyRare // u need observatory or idk what else, hard to find planets ;c
{
    ProximaCentauriB, // exoplanet orbiting in the habitable zone of the red dwarf Proxima Centauri, which is closest star to the sun apart of the triple star system alpha centauri.
    Kepler452b, //only planet discovered by Kepler. Its super-earth exoplanet orbiting within the inner edge of the habitable zone of star Kepler-452
    Wasp17b, // is exoplanet in the constellation Scorpius that is orbiting the star Wasp-17.It is the first planet discovered to have a retrograde orbit, meaning it orbits in a direction counter to the rotation of its host star
    Brahe, // is often called 55 cancri c. Exoplanet in an eccentric orbit around the sun-like star 55 Cancri A. It has mass of almost 1/6 of jupiter or roughly 1/2 of saturn
    EpsilonEridani // is formally named Ran. Is a star in the southern constellation of Eridanus. The star is estimated to be less than a billion years old. Because of its relative youth, Epsilon Eridani has a higher level of magnetic activity than the present-day Sun, with a stellar wind 30 times as strong.

}