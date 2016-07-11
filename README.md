# System Split - OOP Examp, 10 July 2016

<strong>Overview</strong><br />
The System consists, mainly, of two types of components – <strong>Hardware</strong> and <strong>Software</strong> components.<br />
Hardware components have a <strong>name</strong>, a <strong>type</strong>, a <strong>maximum capacity and a maximum memory</strong>.<br />
There are <strong>2 types</strong> of Hardware components:<br />
<ul>
<li><strong>Power Hardware</strong> – decreases <strong>75%</strong> of its given <strong>capacity</strong>, and increases its <strong>memory</strong> by <strong>75%</strong>.</li>
<li><strong>Heavy Hardware</strong> – decreases <strong>25%</strong> of its given <strong>memory</strong> and <strong>doubles</strong> its given <strong>capacity</strong>.</li>
</ul><br />
Software components have a <strong>name</strong>, a <strong>type</strong>, <strong>capacity consumption</strong> and <strong>memory consumption</strong>.
<ul>
<li><strong>Express Software</strong> – <strong>doubles</strong> its given <strong>memory consumption</strong>.</li>
<li><strong>Light Software</strong> – <strong>increases</strong> its given <strong>capacity</strong> consumption by <strong>50%</strong> and <strong>decreases</strong> its given <strong>memory consumption</strong> by <strong>50%</strong>.</li>
</ul><br />
<strong>Example</strong>: If a <strong>Power Hardware</strong> has <strong>150 given capacity</strong>, his capacity will be <strong>– 75%</strong> from <strong>150 =</strong><br />
<strong>150 – ((150 * 3) / 4) =</strong><br />
<strong>150 – (450 / 4) =</strong><br />
<strong>150 – 112 = 38</strong><br />
<strong>Note</strong> that you are working with <strong>INTEGERS.</strong><br />
Software components are <strong>stored on Hardware components</strong>. Each Software component <strong>takes up</strong> a specific amount of <strong>capacity</strong> and a specific amount of <strong>memory</strong> from the <strong>Hardware</strong>, in order to function properly. When registered, a Software component is stored on a <strong>specified Hardware Component</strong>.<br />
There are several main commands you should configure in order for your program to function as needed.<br />

## Commands
<ul><li><strong>RegisterPowerHardware(name, capacity, memory)</strong></li>
<li><strong>RegisterHeavyHardware(name, capacity, memory)</strong></li>
<ul>
<li>Registers a Hardware component of the specified type on The System with the given name, capacity, and memory.</li>
</ul>
<li><strong>RegisterExpressSoftware(hardwareComponentName, name, capacity, memory)</strong></li>
<li><strong>RegisterLightSoftware(hardwareComponentName, name, capacity, memory)</strong></li>
<ul>
<li>Registers a Software component of the <strong>specified type</strong> on the given Hardware component, with the given <strong>name</strong>. The Software Component <strong>takes up</strong> from the <strong>hardware’s capacity and memory</strong> – the given <strong>capacity</strong> and <strong>memory</strong>.</li>
<li>If the given Hardware component <strong>does NOT exist</strong> in The System, the command should do nothing.</li>
<li>If the given Hardware component <strong>does NOT have enough capacity</strong> or <strong>memory</strong> to contain the Software component, the command should do nothing.</li>
</ul>
<li><strong>ReleaseSoftwareComponent(hardwareComponentName, softwareComponentName)</strong></li>
<ul>
<li><strong>Destroys</strong> the Software Component with the given <strong>name</strong>, from the Hardware Component with the given <strong>name</strong>.</li>
<li>In case there is <strong>NO</strong> such <strong>Hardware Component</strong>, in <strong>The System</strong>, the command should do nothing.</li>
<li>In case there is <strong>NO</strong> such <strong>Software Component</strong>, on the given <strong>Hardware Component</strong>, the command should do nothing.</li>
</ul>
<li><strong>Analyze()</strong></li>
<ul>
<li>Shows statistics about the <strong>components currently</strong> in <strong>The System</strong> in the following format:
<strong>“System Analysis</strong><br />
<strong>Hardware Components: {countOfHardwareComponents}</strong><br />
<strong>Software Components: {countOfSoftwareComponents}</strong><br />
<strong>Total Operational Memory: {totalOperationalMemoryInUse} | {maximumMemory}</strong><br />
<strong>Total Capacity Taken: {totalCapacityTaken} | {maximumCapacity}”</strong></li>
<li>The total operational memory in use and total capacity taken is calculated from all the Software components currently in The System. You must also print the maximum memory and capacity available from all the Hardware Components currently in The System.</li>
</ul>
<li><strong>System Split</strong></li>
<ul>
<li>This command finalizes the work of the program, and prints information about the whole System.</li>
<li>The System is split, and all of the Hardware components are to be printed one by one.</li>
<li>The format of printing is the following:<br />
<strong>“Hardware Component – {componentName}</strong><br />
<strong>Express Software Components: {countOfExpressSoftwareComponents}</strong><br />
<strong>Light Software Components: {countOfLightSoftwareComponents}</strong><br />
<strong>Memory Usage: {memoryUsed} | {maximumMemory}</strong><br />
<strong>Capacity Usage: {capacityUsed} | {maximumCapacity}</strong><br />
<strong>Type: {Power/Heavy}</strong><br />
<strong>Software Components: {softwareComponent1, softwareComponent2...}”</strong><br /></li>
<li><strong>Power Hardware Components</strong> must be printed <strong>before</strong> the <strong>Heavy Hardware Components.</strong></li>
<li>When printing <strong>the Software Components</strong>, <strong>print only their names.</strong></li>
<li>In case the Hardware component <strong>does not have any</strong> Software Components, print <strong>“None”.</strong></li>
<li>The general <strong>order of output</strong> for all of the components is – <strong>by order of entrance.</strong></li>
</ul>
</ul>

## Bonus
There is also a bonus task for you to implement in your program.<br />
The System is hyper-dynamic – it is constantly changing its infrastructure. <strong>Addition</strong> and <strong>removal</strong> of components are frequent actions. For data safety reasons, The System contains a <strong>Dump.</strong> The Dump <strong>contains all elements</strong> that are <strong>temporarily deleted,</strong> so they can be <strong>restored</strong> if needed. If, however, the temporarily <strong>deleted components are deleted from The Dump itself,</strong> restoring them would be <strong>impossible.</strong>
<br />
<ul>
<li><strong>Dump(hardwareComponentName)</strong>
<ul>
<li>Removes from The System the Hardware component with the given name, and throws it into The Dump, along with all of its Software components.</li>
<li>Dumped units do NOT take any memory or capacity on The System.</li>
<li>In case there is no component with the given name in The System, the command should do nothing.</li>
</ul>
</li>
<li><strong>Restore(hardwareComponentName)</strong>
<ul>
<li>Dumped units <strong>do NOT take</strong> any <strong>memory</strong> or <strong>capacity</strong> on The System.</li>
<li>In case there is no component with the <strong>given name</strong> in The System, the command should do nothing.</li>
</ul>
</li>
<li><strong>Restore(hardwareComponentName)</strong>
<ul>
<li>Restores the given Hardware component, from <strong>The Dump,</strong> to <strong>The System.</strong></li>
<li>In case there is <strong>NO</strong> such component in The Dump, the command should do nothing.</li>
</ul>
</li>
<li><strong>Destroy(hardwareComponentName)</strong>
<ul>
<li>Removes the given Hardware component from <strong>The Dump.</strong> After this action the component should no longer exist.</li>
<li>In case there is <strong>NO</strong> such component <strong>in The Dump</strong>, the command should do nothing.</li>
</ul>
</li>
<li><strong>DumpAnalyze()</strong>
<ul>
<li>Shows statistics about the dumped System in the following format:<br />
<strong>“Dump Analysis<br />
Power Hardware Components: {countOfPowerHardwareComponents}<br />
Heavy Hardware Components: {countOfHeavyHardwareComponents}<br />
Express Software Components: {countOfExpressSoftwareComponents}<br />
Light Software Components: {countOfLightSoftwareComponents}<br />
Total Dumped Memory: {totalDumpedMemory}<br />
Total Dumped Capacity: {totalDumpedCapacity}”</strong></li>
<li>The dumped memory, capacity, and is calculated from all the components, currently <strong>in The Dump.</strong></li>
</ul>
</li>
</ul>
