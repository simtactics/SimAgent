# Sim Agent

Sim Agent uses a ternary-based state machine that determines the mood at any given moment. I'm assuming this is how it always operates because there is always a "Neutral" state in which they're neither happy or sad.

## Background

I've been making hypothetical proof of concepts of how The Sims possibly works without SimAnatics in ChatGPT. It started with just the basic needs engine until I came to the conclusion that alone doesn't solve how each sim, or agent, could operate when their needs full. But what's the fallback? Turns out a simple ternary logic switch was enough to balance it. After testing it out on a playground, I rewrote that original proof of concept into this.

Still needs a little tweaking. Like even if hunger is really low while the rest are high, the sim's emotional state state remains Neutrual. So the average needs to be calculated. That being said, I am impressed with how this came out.

## License

I hereby waive this project under the public domain - see [LICENSE](LICENSE) for details.
