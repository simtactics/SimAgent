# Sim Agent

Sim Agent uses a ternary-based logic pattern to determine a sim's mood and their emotional state. The Unknown value (similar to Rust's None) replaces "null" and allows for safe fallback to a Neutral state. 

## Background

Using ChatGPT, I've toyed with hypothetical proof of concepts of how The Sims possibly works without SimAnatics. It started with just the basic needs engine until I started running into some problems.

But one problem I kept running into is this Idle state between their red or green states. And if they're red, Sims broadcast said need to any nearby object. How do I solve that? Then I stumbled upon a video about ternary logic patterns. I could use "Unknown" as that idle state and combine that with Sims 4's emotions.

So I fired up prompted for proof of concepts and rewrote myself. Kind of like you see the code on a tutorial and write itself. Granted, I did make sure to test ChatGPT's results in a sandbox.

## License

I hereby waive this project under the public domain - see [LICENSE](LICENSE) for details.
