OOP Advanced Exam - Recycling Station
Waste collection and recycling is big problem for modern societies, as the consumption of goods increases so does the produced waste, thus the need for a fast and efficient way to deal with it is needed. You, as a young and promising programmer, have been tasked with the job to create the software for a recycling station. Since creating software from zero is not an easy task, you found the source code for a framework on the internet to help you.
Core Logic
Your task is to create the software for a Recycling Station, it should keep information about its resources (Energy and Capital), should support operations for processing garbage and printing its current state (its resources). Your Recycling Station should start with 0 Energy and 0 Capital.
Models
The models with which your program should work are the following: Waste, ProcessingData and GarbageDisposalStrategy.
Your program should support three types of Waste - Recyclable garbage, Burnable garbage and Storable garbage. 
Each garbage has a Name, a Weight (in kilograms) and VolumePerKg (in cubic centimeters per kg).
A Garbage Disposal Strategy should implement a single metod processGarbage that takes in a garbage object and processes it. Each garbage type should have a corresponding disposal strategy that knows how to process it and produces a result in the form of a Processing Data object. The processing results should be as follows:
 
	Energy Produced	Energy Used	Capital Earned	Capital Used	   
Recyclable garbage	0	50% of total garbage volume	400 * garbage weight	0	   
Burnable garbage	100% of total garbage volume	20% of total garbage volume	0	0	   
Storable garbage	0	13% of total garbage volume	0	65% of total garbage volume	 
Total garbage volume = garbage weight * garbage volume per kg
A Processing Data object is used to transfer information within the application, it should have the following members - EnergyBalance and CapitalBalance.
Framework Overview
You will be given a namespace “WasteDisposal” which functions as your framework - it exposes its own interfaces and classes as needed. Only code that should belong to the framework should be written in that namespace.
The framework receives and maps strategies for disposal of garbage to attributes inherited from an abstract attribute class it exposes, then when receiving a waste object it searches for a strategy to process it, based on its attribute.
The framework has the following classes:
Attributes
[DisposableAttribute] - An abstract base class for all attributes that specify the disposal strategy. The provided framework requires the passed in attributes to inherit from this one.
 Interfaces
IWaste - An interface exposing the members that a garbage object should possess. All passed in garbage objects should implement this interface.
IGarbageDisposalStrategy - An interface exposing the members that a garbage disposal strategy should possess. Garbage disposal strategies are the objects who understand the actual processing of the garbage and calculate and return the results of the process in the form of a IProcessingData object.
IGarbageProcessor - An interface implemented by the framework’s Garbage Processor.
IStrategyHolder - An interface exposing the members that a strategy collector should implement. Any strategy collector passed to the Garbage Processor should implement this interface.
IProcessingData - An interface exposing the members that a processing data object should possess. The ProcessGarbage method of a strategy should return an object implementing this interface.
Concrete classes
GarbageProcessor - A default implementation of a IGarbageProcessor, it holds a collection of IGarbageDisposalStrategies mapped to specific attribute classes through means of a Strategy Holder object. The Garbage Processor also exposes a method processWaste which resolves what strategy should be used to process the passed in garbage and then delegates the actual processing to that strategy.
StrategyHolder - A default internal implementation to the IStrategyHolder interface, used to provide the default operation of the Waste Disposal Framework. It exposes methods for adding a new Attribute Type -> Garbage Disposal Strategy mapping, removing an Attribute Type and its corresponding strategy and returning a read only copy of the Attribute Type->Garbage Disposal Strategy collection. The internal collection should hold only unique attribute types.
UML Diagram
A UML Diagram is provided for you, so you can better understand the structure and workflow of the framework.
 
User Input
ProcessGarbage {name}|{weight}|{volumePerKg}|{type}
Receives a garbage for processing with the given name, weight and volume per kilogram from the specified type.
The {name} will be a non-empty string consisting of only alphanumerical characters.
The {weight} will be a valid positive double.
The {volumePerKg} will be a valid positive double.
The {type} will always be one of the following “Recyclable”, “Burnable” or “Storable”.
After processing the passed in garbage print the following message “{garbage Weight} kg of {garbageName} successfully processed!”.
Status
Prints information about the current balance of the Recycling Station in the following format “Energy: {energyBalance} Capital: {capitalBalance}”.
Input
Input will be received through the console.
Each command will come on a new line.
The input ends when you receive the command “TimeToRecycle”.
Output
Print each input command’s resulting message on a new line.
Constraints
All floating point numbers should be printed to the second decimal place (ex. EnergyBalance, Weight, VolumePerKg… e.t.c.)
All numbers passed in through the input will be valid doubles.
All strings passed in through the input will be valid non-empty strings consisting of only alphanumerical characters.
All commands passed through the input will be valid.
The last command received through the input will always be “TimeToRecycle”.

TASKS:
Refactor and use the Framework
The framework you have is decently written, but it might violate some of the principles of good object oriented design and general coding guidelines or contain a few minor bugs. Refactor any problems you find in the framework. You are allowed to refactor any parts of it, except the interfaces (which it still has to implement), if you think that will improve its overall quality. Your code MUST use the provided framework, spend some time to understand how it works and build your code to use the provided functionality.
20 score
Correct results in Judge
The framework provides some functionality, but it doesn’t cover the entire task, implement the rest of the business logic, meeting the specification requirements. Test your code in the automated Judge system.

NOTE: Competitive tests 11-15 and zero test 3 are reserved for the Bonus Task. Passing Tests 1-10 will grant you the full 20 score for this task.
20 score
High Quality
Achieve good separation of concerns using abstractions and interfaces to decouple classes, while reusing code through inheritance and polymorphism. Your classes should have strong cohesion - have single responsibility and loose coupling - know about as few other classes as possible.
25 score
Reusability
Your code should be modular, reusable and extendable, following the best practices of OOP and High Quality Code. Extend your program to be able to handle ANY garbage type - in other words newly introduced model classes should be able to work with your program without the need to rewrite any core logic.

15 score
Unit Testing
Test the framework classes implementing the IGarbageProcessor and IStrategyHolder interfaces (by default those should be GarbageProcessor and StorageHolder). Extensive testing might require you to have some of the core logic implemented, in order to cover all cases. Mock all dependencies when testing a class.
20 score
*Bonus Task - Extended Functionality
Extend your program to support a new command ChangeManagmentRequirement. 
User Input
ChangeManagementRequirement {energyBalance}|{capitalBalance}|{garbageType}
Receives a new management requirment with the given energyBalance and capitalBalance, denying the specified garbageType.
The {energyBalance } will be a valid double.
The {capitalBalance} will be a valid double.
The {garbageType} will always be one of the following “Recyclable”, “Burnable” or “Storable”.
When a new managemet requirement is received you should print “Management requirement changed!”.
Your program should be able to deny processing a specific type of garbage when either the Recycling Station’s Energy OR Capital is under the requirment specified ammounts. If a ProcessingGarbage command is denied, instead of it’s usual message it prints “Processing Denied!”.During operation of your program new management requirments can be received that should REPLACE the previous management requirment. By default your program should start without a management requirement (i.e. all garbage types are accepted regardless of Energy or Capital values).
For an example of how the management requirements work - if the current management requirment is set to 100 Energy and 150 Capital, with denied garbage Type - Recyclable, and the Recycling Station has 90 Energy and 200 Capital. Receiving an input to Process a garbage of type Recyclable, the processing request will be DENIED, because currently the Recycling Station’s Energy (90) is bellow the requirment criteria for energy (100). 
It is important to note that when a management requirment is received, it STAYS in effect untill a new management requirement overwrites it. Management requirements also impose their check ONLY on the specified garbage type – if in the above example the garbage type we had received was of any other type than Recyclable it would have been processed regardless of the Recycling Station’s Energy and Capital values.Check the examples to better grasp how the management requirement works. 
NOTE: Competitive tests 11-15 and zero test 3 are reserved for this Task. Passing Tests 11-15 will grant you the 10 score for this task.
